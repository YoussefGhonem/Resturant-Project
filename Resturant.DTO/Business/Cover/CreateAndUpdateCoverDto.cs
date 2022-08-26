using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Cover
{
    public class CreateAndUpdateCoverDto
    {
        public List<IFormFile>? Images { get; set; }
    }
}
