using Microsoft.AspNetCore.Identity;

namespace Resturant.Data.DbModels.SecuritySchema
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
