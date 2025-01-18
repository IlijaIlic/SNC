using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class OceneFotograf
    {

        [Key]
        public int ID { get; set; }

        public float Ocena { get; set; }

        [ForeignKey("Fotograf")]
        public int FotografID { get; set; }

    }
}
