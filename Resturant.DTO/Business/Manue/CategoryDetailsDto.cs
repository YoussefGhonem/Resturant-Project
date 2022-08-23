namespace Resturant.Services.manue.Models
{
    public class CategoryDetailsDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public string? CategoryFileUrl { get; set; }
        public string? CategoryFileName { get; set; }
    }
}
