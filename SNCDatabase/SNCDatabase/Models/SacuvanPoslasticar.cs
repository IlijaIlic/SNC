using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class SacuvanPoslasticar
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }
    }
}
