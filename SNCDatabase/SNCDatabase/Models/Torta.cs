using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class Torta
    {
        [Key]
        public int Id { get; set; }

        public string? Naziv { get; set; }

        public string? Cena { get; set; }

        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }

    }
}
