using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema.About
{
    [Table("Community", Schema = "Business")]
    public class Community : BaseEntity
    {
        public Guid Id { get; set; }
        public string? name { get; set; }
        public string? Desciption { get; set; }
        public string? ImageUrl { get; set; }
    }
}
