using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Jop", Schema = "Business")]
    public class Jop : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CoverLatter { get; set; }
        public string? AttachmentPath { get; set; }
    }
}
