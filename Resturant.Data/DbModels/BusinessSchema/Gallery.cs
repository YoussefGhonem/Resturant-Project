using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Gallery", Schema = "Business")]
    public class Gallery : BaseEntity
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}   
