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
    }
}
