using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.AboutAndCommuniry
{
    public class CreateAndUpdateCommunity
    {
        public string? name { get; set; }
        public string? Desciption { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
