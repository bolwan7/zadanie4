using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace zadanie4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;

        public ICollection<ProfilUzytkownika>? Profiles { get; set; }
    }
}
