using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string  UID { get; set; }

        [Required]
        public required string Tip { get; set; }

        [ForeignKey("Admin")]
        public int AdminID { get; set; }

        [ForeignKey("Mladenci")]
        public int MladenciID { get; set; }

        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }

        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }

        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }

        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }



    }
}
