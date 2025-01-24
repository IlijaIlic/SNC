using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SNCDatabase.Models
{
    public class Zakazano
    {

        [Key]
        public int ID { get; set; }

        [AllowNull]

        public DateTime RestoranTermin { get; set; }

        [AllowNull]
        public DateTime PoslasticarTermin { get; set; }

        [AllowNull]
        public DateTime FotografTermin { get; set; }

        [AllowNull]
        public DateTime DekoraterTermin { get; set; }

        [AllowNull]
        public int CenaRestorana { get; set; }

        [AllowNull]
        public int CenaPoslasticara { get; set; }

        [AllowNull]
        public string? NazivTorte { get; set; }

        [AllowNull]
        [ForeignKey("Mladenci")]
        public int MladenciID { get; set; }

        [AllowNull]
        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }

        [AllowNull]
        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }

        [AllowNull]
        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }

        [AllowNull]
        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }


    }
}
