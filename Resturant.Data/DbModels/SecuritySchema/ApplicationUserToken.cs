using Microsoft.AspNetCore.Identity;

namespace Resturant.Data.DbModels.SecuritySchema
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
