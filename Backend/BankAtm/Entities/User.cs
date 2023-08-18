using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAtm.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
