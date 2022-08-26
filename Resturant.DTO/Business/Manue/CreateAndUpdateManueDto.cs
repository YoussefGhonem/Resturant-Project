using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Manue
{
    public class UpdateManueCategoryDto
    {
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
