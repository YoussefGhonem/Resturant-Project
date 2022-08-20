using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Cover", Schema = "Business")]
    public class Cover : BaseEntity
    {
        public Guid Id { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
