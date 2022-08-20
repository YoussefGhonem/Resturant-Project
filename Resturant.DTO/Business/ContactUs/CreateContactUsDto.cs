using Resturant.Core.Enums;

namespace Resturant.DTO.Business.ContactUs
{
    public class CreateContactUsDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public TouchAbout? TouchAbout { get; set; }
        public string? Massage { get; set; }
    }
}
