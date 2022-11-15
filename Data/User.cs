using Microsoft.AspNetCore.Identity;

namespace SimpleApp.Data
{
    public class User :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
