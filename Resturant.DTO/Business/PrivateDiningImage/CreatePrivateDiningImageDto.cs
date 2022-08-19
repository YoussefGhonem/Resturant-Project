using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.PrivateDiningImage
{
    public class CreatePrivateDiningImageDto
    {
        public List<IFormFile> Images { get; set; }
    }
}
