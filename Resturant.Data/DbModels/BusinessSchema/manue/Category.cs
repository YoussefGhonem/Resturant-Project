using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("Categories", Schema = "Business")]
    public class Category : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public string? CategoryFileUrl { get; set; }
        public string? CategoryFileName { get; set; }
        public virtual Manu? Manu { get; set; }
        public virtual ICollection<Subcategory>? SubCatogries { get; set; }
    }
}
