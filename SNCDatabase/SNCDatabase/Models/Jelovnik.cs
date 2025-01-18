using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class Jelovnik
    {
        [Key]
        public int ID { get; set; }
       
        public string? ImeJela { get; set; }

        public string? TipJela { get; set; }

        public int Kolicina { get; set; }

        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }

    }
}
