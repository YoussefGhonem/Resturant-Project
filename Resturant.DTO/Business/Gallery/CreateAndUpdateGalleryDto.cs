using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Gallery
{
    public class CreateAndUpdateGalleryDto
    {
        public string? Name { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
