using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class Zakazano
    {

        [Key]
        public int ID { get; set; }

        public DateTime RestoranTermin { get; set; }
        
        public DateTime PoslasticarTermin { get; set; }
        
        public DateTime FotografTermin { get; set; }
        
        public DateTime DekoraterTermin { get; set; }

        public int CenaRestorana { get; set; }

        public int CenaPoslasticara { get; set; }

        public string? NazivTorte { get; set; }

        [ForeignKey("Mladenci")]
        public int MladenciID { get; set; }

        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }

        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }

        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }

        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }


    }
}
