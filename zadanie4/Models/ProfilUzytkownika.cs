using System;
using System.ComponentModel.DataAnnotations;

namespace zadanie4.Models
{
    public class ProfilUzytkownika
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Imie { get; set; } = null!;

        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public int Cialo { get; set; }
        public int Umysl { get; set; }
        public int Relacje { get; set; }
        public int Praca { get; set; }
        public int Duchowosc { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}