using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("Category", Schema = "Business")]
    public class Category : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public Manue? manue { get; set; }
        public Guid? manueId { get; set; }
        public  ICollection<Subcategory>? subCatogry { get; set; }
    }
}
