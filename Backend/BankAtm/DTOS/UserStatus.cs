using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class UserStatus
    {
        [Required(ErrorMessage = "Enter Account Number")]
        public long AccNum { get; set; }

        [Required(ErrorMessage ="Enter Account Status")]
        public string AccStatus { get; set; }
    }
}
