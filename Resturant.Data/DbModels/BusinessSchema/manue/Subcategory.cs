using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("Subcategory", Schema = "Business")]
    public class Subcategory : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? price { get; set; }
        public string? value { get; set; }
        public Category? category { get; set; }
        public Guid? categoryId { get; set; }
    }
}
