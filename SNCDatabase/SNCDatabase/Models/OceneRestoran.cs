using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class OceneRestoran
    {

        [Key]
        public int ID { get; set; }

        public float Ocena { get; set; }

        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }
    }
}
