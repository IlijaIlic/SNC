using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class SlikeRestoran
    {
        [Key]
        public int ID { get; set; }

        // SLIKA KAKO SE PREDSTAVITI
        public string? SLIKE { get; set; }

        public string? RestoranUID { get; set; }

        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }
    }
}
