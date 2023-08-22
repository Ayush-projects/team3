using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class CustomerAddress
    {
        [Required(ErrorMessage = "Please enter Customer ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Address"), MaxLength(40), RegularExpression(@"^\b[\dA-Za-z\s\-\\]+\b$", ErrorMessage = "Only letters and numbers")]
        public string Address { get; set; }
    }
}
