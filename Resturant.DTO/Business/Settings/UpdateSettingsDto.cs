using Microsoft.AspNetCore.Http;

namespace Resturant.DTO.Business.Settings
{
    public class UpdateSettingsDto
    {
        // Update About Us Settings
        public string? AboutUs { get; set; }
        public string? EmailService { get; set; }
        public string? NumberService { get; set; }
        public string? WorkWithUsDescription { get; set; }

        // Update Private Dining
        public IFormFile? Document { get; set; }
        public string? PrivateDiningDescription { get; set; }
    }
    public class SettingsDetailsDto
    {
        public string? AboutUs { get; set; }
        public string? EmailService { get; set; }
        public string? NumberService { get; set; }
        public string? WorkWithUsDescription { get; set; }
        public string? PrivateDiningAttachmentName { get; set; }
        public string? PrivateDiningAttachmentPath { get; set; }
        public string? PrivateDiningDescription { get; set; }

        public string? privateDiningCoverAttachmentName { get; set; }
        public string? privateDiningCoverAttachmentPath { get; set; }
        //menu photo propps For Cover Photo
        public string? ManuAttachmentName { get; set; }
        public string? ManuAttachmentPath { get; set; }
        // About Cover Photo 
        public string? AboutAttachmentName { get; set; }
        public string? AboutAttachmentPath { get; set; }

    }
}
