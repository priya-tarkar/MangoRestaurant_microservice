using Microsoft.AspNetCore.Identity;

namespace Microsoft.Identity.Services.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}
