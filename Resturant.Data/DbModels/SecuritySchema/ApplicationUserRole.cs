﻿using Microsoft.AspNetCore.Identity;

namespace Resturant.Data.DbModels.SecuritySchema
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
