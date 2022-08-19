using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturant.Data;
using Resturant.Data.DbModels.SecuritySchema;

namespace Resturant.Services.Identity.Extensions
{
    public static class ValidationExtension
    {
        public static async Task<bool> BeExistUser(AppDbContext context, string email)
        {
            var user = await context.Users
                .Where(user => user.Email == email)
                .Include(user => user.UserRoles).ThenInclude(role => role.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync();

            if (user == null) return false;
            return true;
        }
        public static async Task<bool> BeEmailUnique(this UserManager<ApplicationUser> userManager, string email)
        {
            var emailFound = await userManager.FindByEmailAsync(email.Trim().ToLower());
            if (emailFound == null)
            {
                return true;
            }
            return false;
        }
    }
}
