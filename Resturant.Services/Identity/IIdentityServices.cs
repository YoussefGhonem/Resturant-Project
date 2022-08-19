using Microsoft.AspNetCore.Http;
using Resturant.Core.Interfaces;
using Resturant.DTO.Security.Identity;
using Resturant.DTO.Security.User;

namespace Resturant.Services.Identity
{
    public interface IIdentityServices
    {
        Task<string> Login(LoginDto login);
        Task<IResponseDTO> Register(RegisterDto model);
        Task<IResponseDTO> ResetPassword(ResetPasswordDto options);
        Task<IResponseDTO> ChangePassword(Guid userId, ChangePasswordDto options);
        Task<IResponseDTO> UpdateUserProfile(int id, UpdateUserProfile options, IFormFile file);
        Task<IResponseDTO> ForgetPassword(string email);
    }
}
