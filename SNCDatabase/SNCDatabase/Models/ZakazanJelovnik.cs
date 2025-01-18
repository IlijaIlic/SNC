using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class ZakazanJelovnik
    {
        [Key]
        public int ID { get; set; }

        public string? ImeJela { get; set; }

        public string? TipJela { get; set; }

        public int Cena { get; set; }

        public float Gramaza { get; set; }


        [ForeignKey("Mladenci")]
        public int MladenciID { get; set; }


    }
}
