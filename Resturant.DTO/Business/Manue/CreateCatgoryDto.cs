using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Resturant.DTO.Business.Manue
{

    public class CreateManuCategoryDto
    {
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public IFormFile? File { get; set; }
        public SubCategoryDto SubCatogries { get; set; }

    }
    public class SubCategoryDto
    {
        public string? Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? Description { get; set; }
        public ICollection<MealNameDto> MealNames { get; set; }

    }
    public class MealNameDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }

    }
}
