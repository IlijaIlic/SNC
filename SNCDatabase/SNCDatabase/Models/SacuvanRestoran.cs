using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class SacuvanRestoran
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }
    }
}
