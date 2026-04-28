using Microsoft.AspNetCore.Identity;

namespace YourProject.Models
{
    public class Client : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string EducationLevel { get; set; }
    }
}