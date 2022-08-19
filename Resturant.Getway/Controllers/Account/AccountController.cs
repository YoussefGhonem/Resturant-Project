using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.CurrentUser;
using Resturant.Core.Interfaces;
using Resturant.DTO.Security.Identity;
using Resturant.Services.Identity;

namespace Resturant.Getway.Controllers.Account
{
    [Route("api/account")]
    public class AccountController : BaseController
    {
        private readonly IIdentityServices _accountService;
        public AccountController(
           IIdentityServices accountService,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _accountService = accountService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            return Ok(await _accountService.Login(login));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IResponseDTO> Register(RegisterDto registerDto)
        {
            _response = await _accountService.Register(registerDto);
            return _response;
        }

        [AllowAnonymous]
        [Route("reset-password")]
        [HttpPost]
        public async Task<IResponseDTO> ResetPassword([FromBody] ResetPasswordDto options)
        {
            _response = await _accountService.ResetPassword(options);
            return _response;
        }



        [AllowAnonymous]
        [Route("forget-password/{email}")]
        [HttpPost]
        public async Task<IResponseDTO> ForgetPassword(string email)
        {
            _response = await _accountService.ForgetPassword(email);
            return _response;
        }

        [Route("change-password")]
        [HttpPost]
        public async Task<IResponseDTO> ChangePassword([FromBody] ChangePasswordDto options)
        {
            _response = await _accountService.ChangePassword(CurrentUser.Id.Value, options);
            return _response;
        }
    }
}