using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class SacuvanFotograf
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }

    }
}
