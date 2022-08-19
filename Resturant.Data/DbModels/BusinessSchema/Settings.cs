using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("Settings", Schema = "ApplicationSettings")]
    public class Settings : BaseEntity
    {
        public string? AboutUs { get; set; }
        public string? EmailService { get; set; }
        public string? NumberService { get; set; }
        public string? PrivateDiningDescription { get; set; }
        public string? WorkWithUsDescription { get; set; }

        // file info
        public string? PrivateDiningAttachmentName { get; set; }
        public string? PrivateDiningAttachmentPath { get; set; }

    }
}
