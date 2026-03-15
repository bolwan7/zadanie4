using System.ComponentModel.DataAnnotations;

namespace zadanie4.Models
{
    public class Odpowiedz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tresc { get; set; } = null!;

        public int PytanieId { get; set; }
        public Pytanie? Pytanie { get; set; }

        public int PunktyCialo { get; set; }
        public int PunktyUmysl { get; set; }
        public int PunktyRelacje { get; set; }
        public int PunktyPraca { get; set; }
        public int PunktyDuchowosc { get; set; }
    }
}