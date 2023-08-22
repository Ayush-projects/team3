using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class CustomerContNo
    {
        [Required(ErrorMessage = "Please enter Customer ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter ContactNo"), RegularExpression("[6-9][0-9]{9}", ErrorMessage = "Enter valid Contact number")]
        public string ContactNo { get; set; }
    }
}
