using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("Manu", Schema = "Business")]
    public class Manu : BaseEntity
    {
        public new Guid Id { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
    }
}
