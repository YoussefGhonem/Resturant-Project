using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resturant.Core.Enums;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.SecuritySchema;
using Resturant.DTO.Security.Identity;
using Resturant.DTO.Security.User;
using Resturant.Services.Identity.Extensions;
using Resturant.Services.SendingEmail;
using System.Web;

namespace Resturant.Services.Identity
{
    public class IdentityServices : IIdentityServices
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IResponseDTO _response;
        private readonly ISendingEmailService _sendingEmailService;

        public IdentityServices(ISendingEmailService sendingEmailService, AppDbContext context, IConfiguration configuration, IResponseDTO response, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _response = response;
            _sendingEmailService = sendingEmailService;
            _userManager = userManager;
        }
        public async Task<IResponseDTO> ChangePassword(Guid userId, ChangePasswordDto options)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ChangePasswordAsync(user, options.CurrentPassword, options.NewPassword);

            if (result.Succeeded)
            {
                _response.IsPassed = true;
                return _response;
            };

            var errors = result.Errors.Select(x => x.Description).ToList();
            throw new Exception(string.Join(",", errors));
        }
        public async Task<IResponseDTO> ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = HttpUtility.UrlEncode(token);

            // send email
            await _sendingEmailService.BeforeResetPassword(user.Id, encodedToken);

            _response.IsPassed = true;
            return _response;
        }
        public async Task<string> Login(LoginDto model)
        {
            if (!await ValidationExtension.BeExistUser(_context, model.Email)) return "Not Found";


            var user = await _context.Users
                                      .Include(u => u.UserRoles).ThenInclude(userRole => userRole.Role)
                                      .Include(user => user.Claims)
                                      .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null) return "";

            var token = JsonWebTokenGeneration.GenerateJwtToken(_configuration, user);

            return token;
        }
        public async Task<IResponseDTO> Register(RegisterDto request)
        {
            var emailFound = await _userManager.FindByEmailAsync(request.Email.Trim().ToLower());
            if (emailFound != null)
            {
                _response.IsPassed = false;
                _response.Errors.Add("This email is Exist");
                return _response;
            }

            var rolesFromDb = _context.Roles.FirstOrDefault(x => x.Name == ApplicationRolesEnum.Customer.ToString());

            var userRole = new ApplicationUserRole()
            {
                Role = rolesFromDb,
                RoleId = rolesFromDb.Id
            };

            var applicationUser = new ApplicationUser()
            {
                EmailConfirmed = true,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                LockoutEnabled = false,
                UserRoles = new List<ApplicationUserRole>() { userRole }
            };
            var result = await _userManager.CreateAsync(applicationUser, request.Password);

            if (result.Succeeded)
            {
                _response.IsPassed = true;
                return _response;
            }
            _response.IsPassed = false;
            return _response;
        }
        public async Task<IResponseDTO> ResetPassword(ResetPasswordDto request)
        {
            if (await ValidationExtension.BeExistUser(_context, request.Email))
            {
                _response.IsPassed = false;
                _response.Errors.Add("This email not found");
                return _response;
            };
            var user = await _userManager.FindByEmailAsync(request.Email);

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                throw new Exception(string.Join(",", errors));
            }
            _response.IsPassed = true;
            return _response;
        }
        public Task<IResponseDTO> UpdateUserProfile(int id, UpdateUserProfile options, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
