using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("ManuCategories", Schema = "Business")]
    public class ManuCategory : BaseEntity
    {
        public ManuCategory()
        {
            SubCatogries = new HashSet<Subcategory>();
        }
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? WorkDayes { get; set; }
        public string? Description { get; set; }
        public string? CategoryFileUrl { get; set; }
        public string? CategoryFileName { get; set; }
        public virtual ICollection<Subcategory>? SubCatogries { get; set; }
    }
}
