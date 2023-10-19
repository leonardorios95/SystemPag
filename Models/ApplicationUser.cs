using Microsoft.AspNetCore.Identity;

namespace SystemPag.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CPF { get; set; }
        
    }
}
