using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class AuthRequest
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid MailID ")]

        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        
    }
}
