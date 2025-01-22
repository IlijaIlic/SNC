using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        [AllowNull]
        [ForeignKey("Admin")]
        public int AdminID { get; set; }

        [AllowNull]
        [ForeignKey("Mladenci")]
        public int MladenciID { get; set; }

        [AllowNull]
        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }

        [AllowNull]
        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }

        [AllowNull]
        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }

        [AllowNull]
        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }



    }
}
