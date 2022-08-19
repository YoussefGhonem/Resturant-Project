using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Press", Schema = "Business")]
    public class Press : BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HyperLink { get; set; }

        // file info
        public string? AttachmentName { get; set; }
        public string? AttachmentPath { get; set; }
        public string? AttachmentExtension { get; set; }

    }
}
