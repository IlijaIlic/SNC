using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class SlikeDekorater
    {
        [Key]
        public int ID { get; set; }

        // SLIKA KAKO SE PREDSTAVITI
        public int SLIKE { get; set; }

        public required string DekoraterUID { get; set; }

        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }

    }
}
