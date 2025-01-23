using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class Mladenci
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string? BrojTelefona { get; set; }

        public string? Email { get; set; }

        [Required]  
        public string? Sifra { get; set; }

        public string? ImePartneta { get; set; }

        public string? PrezimePartnera { get; set; }

    }
}
