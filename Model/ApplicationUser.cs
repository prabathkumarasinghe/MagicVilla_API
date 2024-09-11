using Microsoft.AspNetCore.Identity;

namespace MagicVilla.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
