﻿using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("SubCategories", Schema = "Business")]
    public class Subcategory : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<MealName>? MealNames { get; set; }
    }
}
