using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class OcenePoslasticar
    {

        [Key]
        public int ID { get; set; }

        public float Ocena { get; set; }

        [ForeignKey("Poslasticar")]
        public int PoslasticarID { get; set; }
    }
}
