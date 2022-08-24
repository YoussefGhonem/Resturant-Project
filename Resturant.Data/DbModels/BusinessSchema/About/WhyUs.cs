using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema.About
{

    [Table("WhyUss", Schema = "Business")]
    public class WhyUs : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Quetion { get; set; }
        public string? Answer { get; set; }
    }
}
