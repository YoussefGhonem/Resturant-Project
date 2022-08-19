using Resturant.Core.Common;
using Resturant.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Meals", Schema = "Business")]

    public class Meal : BaseEntity
    {
        public Guid Id { get; set; }
        public MealEnum? MealName { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

        public virtual Location? Location { get; set; }
    }
}
