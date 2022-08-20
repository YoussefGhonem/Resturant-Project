using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Manue
{

    public class CreateManuCategoryDto
    {
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<SubCategoryDto>? SubCatogries { get; set; }
        public IFormFile? File { get; set; }

    }
    public class SubCategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<MealNameDto>? MealNames { get; set; }

    }
    public class MealNameDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }

    }
}
