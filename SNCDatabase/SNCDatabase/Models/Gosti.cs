using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNCDatabase.Models
{
    public class Gosti
    {
        [Key]
        public int ID { get; set; }

        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public int brojStola { get; set; }

        [ForeignKey("Mladenci")]
        public int MladenciID { get; set; }
    }
}
