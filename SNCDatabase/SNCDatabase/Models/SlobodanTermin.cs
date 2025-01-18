using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class SlobodanTermin
    {

        [Key]
        public int ID { get; set; }

        public DateTime Termin { get; set; }

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
