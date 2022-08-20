using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Happining", Schema = "Business")]
    public class Happining : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageName { get; set; }
    }
}
