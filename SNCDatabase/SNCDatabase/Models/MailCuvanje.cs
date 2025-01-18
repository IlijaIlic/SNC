using System.ComponentModel.DataAnnotations;

namespace SNCDatabase.Models
{
    public class MailCuvanje
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Email { get; set; }

    }
}
