using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class OceneDekorater
    {

        [Key]
        public int ID { get; set; }

        public float Ocena { get; set; }

        [ForeignKey("Dekorater")]
        public int DekoraterID { get; set; }
    }
}
