using System.Text.Json.Serialization;

namespace Resturant.DTO.Security.User
{
    public class UpdateUserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
