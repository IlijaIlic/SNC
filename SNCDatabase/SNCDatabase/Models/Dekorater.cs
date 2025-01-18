using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class Dekorater
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        [Required]
        public required string SigurnosniKod { get; set; }

        public string? Naziv { get; set; }

        public string? Opis { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Sifra { get; set; }

        public string? Lokacija { get; set; }

        public int Cena { get; set; }

        public DateTime DatumOsnivanja { get; set; }

        public float Ocena { get; set; }

        public string? BrojTelefona { get; set; }



    }
}
