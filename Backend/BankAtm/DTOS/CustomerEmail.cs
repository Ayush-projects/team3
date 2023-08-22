using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class CustomerEmail
    {
        [Required(ErrorMessage ="Please enter Customer ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Email"), EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
    }
}
