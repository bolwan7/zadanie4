using System.Collections.Generic;
using zadanie4.Models;

namespace zadanie4.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser? User { get; set; }
        public List<ProfilUzytkownika> Profiles { get; set; } = new List<ProfilUzytkownika>();
    }
}
