using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("MealNames", Schema = "Business")]
    public class MealName : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }

    }
}
