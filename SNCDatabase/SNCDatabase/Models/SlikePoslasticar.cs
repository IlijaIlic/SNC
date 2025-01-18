using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class SlikePoslasticar
    {

        [Key]
        public int ID { get; set; }

        // SLIKA KAKO SE PREDSTAVITI
        public int SLIKE { get; set; }

        public required string PoslasticarUID { get; set; }

        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }
    }
}
