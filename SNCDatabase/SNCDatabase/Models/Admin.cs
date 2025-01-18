using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public required string UID { get; set; }
        
        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string? Email { get; set; }

        public string? Sifra { get; set; }

    }
}
