using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Manue
{
    public class CreateAndUpdateManueDto
    {
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public ICollection<SubCategoryDto>? SubCatogries { get; set; }
        public IFormFile? File { get; set; }
    }
}
