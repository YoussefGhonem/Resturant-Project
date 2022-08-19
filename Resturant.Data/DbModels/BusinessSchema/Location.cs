using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Locations", Schema = "Business")]

    public class Location : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Adress { get; set; }
        public string? GpsLink { get; set; }
        public virtual ICollection<Meal>? Meals { get; set; }
    }
}
