using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SNCDatabase.Models
{
    public class SlobodanTermin
    {

        [Key]
        public int ID { get; set; }

        public DateTime Termin { get; set; }

        [AllowNull]
        [ForeignKey("Fotograf")]
        public int? FotografID { get; set; }

        [AllowNull]
        [ForeignKey("Poslasticar")]
        public int? PoslasticarID { get; set; }

        [AllowNull]
        [ForeignKey("Dekorater")]
        public int? DekoraterID { get; set; }

        [AllowNull]
        [ForeignKey("Restoran")]
        public int? RestoranID { get; set; }

    }
}
