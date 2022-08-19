using Microsoft.AspNetCore.Identity;

namespace Resturant.Data.DbModels.SecuritySchema
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
