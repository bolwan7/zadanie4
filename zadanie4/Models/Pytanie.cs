using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zadanie4.Models
{
    public class Pytanie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tresc { get; set; } = null!;

        public string Typ { get; set; } = "choice";

        public List<Odpowiedz> Odpowiedzi { get; set; } = new List<Odpowiedz>();
    }
}