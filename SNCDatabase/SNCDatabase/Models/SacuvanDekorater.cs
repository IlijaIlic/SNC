using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class SacuvanDekorater
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string UID { get; set; }

        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }
    }
}
