using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("PrivateDiningImages", Schema = "Business")]

    public class PrivateDiningImage : BaseEntity
    {
        public Guid Id { get; set; }
        // file info
        public string? AttachmentName { get; set; }
        public string? AttachmentPath { get; set; }
    }
}
