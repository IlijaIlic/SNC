using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class SlikeFotograf
    {
        [Key]
        public int ID { get; set; }

        // SLIKA KAKO SE PREDSTAVITI
        public int SLIKE { get; set; }

        public required string FotografUID { get; set; }

        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }
    }
}
