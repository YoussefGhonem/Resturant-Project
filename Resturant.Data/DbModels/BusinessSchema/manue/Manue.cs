using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema.manue
{
    [Table("Manue", Schema = "Business")]
    public class Manue : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Category>? Categorys { get; set; }
    }
}
