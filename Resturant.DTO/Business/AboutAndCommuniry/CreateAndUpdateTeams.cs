using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.AboutAndCommuniry
{
    public class CreateAndUpdateTeams
    {
        public string? Name { get; set; }
        public string? JopTitle { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
