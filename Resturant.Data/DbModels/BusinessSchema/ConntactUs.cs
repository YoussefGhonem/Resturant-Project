using Resturant.Core.Common;
using Resturant.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("ConntactUs", Schema = "Business")]
    public class ConntactUs : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public TouchAbout? TouchAbout { get; set; }
        public string? Massage { get; set; }
    }
}
