using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Happining
{
    public class CreateAndUpdateHappiningDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
