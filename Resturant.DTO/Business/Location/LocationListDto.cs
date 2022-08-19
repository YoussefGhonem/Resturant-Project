using Resturant.Data.DbModels.BusinessSchema;

namespace Resturant.DTO.Business.Location
{
    public class LocationListDto
    {
        public Guid Id { get; set; }
        public string? Adress { get; set; }
        public string? GpsLink { get; set; }
        public virtual ICollection<MealDto>? Meals { get; set; }
    }
}
