using Microsoft.AspNetCore.Identity;

namespace PruebaTecnica.WEB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
