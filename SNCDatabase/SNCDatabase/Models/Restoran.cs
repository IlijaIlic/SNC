using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class Restoran
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        public required string SigurnosniKod { get; set; }

        public string? Naziv { get; set; }

        public string? Opis { get; set; }
   
        public string? Email { get; set; }

        public string? Sifra { get; set; }

        public string? Lokacija { get; set; }

        public int Cena { get; set; }

        public DateTime DatumOsnivanja { get; set; }

        public float? Ocena  { get; set; }  //ja sam promenio
        
        public string? BrojTelefona { get; set; }
        
        public bool PraviTortu { get; set; }






    }
}
