using Nest;
using Resturant.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Data.DbModels.BusinessSchema.About
{
    [Table("Team", Schema = "Business")]
    public class Team : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? JopTitle { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        //public AboutUs? About { get; set; }
        //public Guid? AboutId { get; set; }
    }
}
