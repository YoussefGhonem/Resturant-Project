﻿using Microsoft.AspNetCore.Identity;

namespace Resturant.Data.DbModels.SecuritySchema
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string DisplayName { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
