using Resturant.Core.Common;
using Resturant.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Appointments", Schema = "Business")]

    public class Appointment : BaseEntity
    {
        public Guid Id { get; set; }
        public DaysEnum? From { get; set; }
        public DaysEnum? To { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }

        public virtual Meal Meal { get; set; }



    }
}
