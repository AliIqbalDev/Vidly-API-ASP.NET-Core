using Microsoft.AspNetCore.Identity;

namespace Vidly_RESTful_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RefreshToken { get; set; }
    }
}