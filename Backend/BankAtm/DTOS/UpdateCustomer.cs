using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class UpdateCustomer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter ContactNo"), RegularExpression("[6-9][0-9]{9}", ErrorMessage = "Enter valid Contact number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please enter Address"), MaxLength(40), RegularExpression(@"^\b[\dA-Za-z\s\-\\]+\b$", ErrorMessage = "Only letters and numbers")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter Email"), EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
    }
}
