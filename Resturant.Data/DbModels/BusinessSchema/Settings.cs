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

        //privateDining Cover Photo props
        public string? privateDiningCoverAttachmentName { get; set; }
        public string? privateDiningCoverAttachmentPath { get; set; }
        //menu photo propps For Cover Photo
        public string? ManuAttachmentName{ get; set; }
        public string? ManuAttachmentPath { get; set; }
        // About Cover Photo 
        public string? AboutAttachmentName { get; set; }
        public string? AboutAttachmentPath { get; set; }


    }
}
