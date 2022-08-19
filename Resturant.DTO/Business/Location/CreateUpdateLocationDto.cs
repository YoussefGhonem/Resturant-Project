using Resturant.Core.Enums;
using Resturant.Data.DbModels.BusinessSchema;

namespace Resturant.DTO.Business.Location
{
    public class CreateUpdateLocationDto
    {
        public string? Adress { get; set; }
        public string? GpsLink { get; set; }
        public ICollection<MealDto>? Meals { get; set; }
    }
    public class MealDto
    {
        public MealEnum? MealName { get; set; }
        public ICollection<AppointmentDto>? Appointments { get; set; }
    }
    public class AppointmentDto
    {
        public DaysEnum? From { get; set; }
        public DaysEnum? To { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
    }
}
