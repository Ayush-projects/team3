using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class ChangePinDTO
    {

        [Required(ErrorMessage = "Please Enter Account Number")]
        public long AccNum { get; set; }

        [Required(ErrorMessage = "Please Enter Card No"), StringLength(16)]
        public string CardNo { get; set; }

        [Required(ErrorMessage = "Please enter old Atm Pin"), StringLength(4)]
        public string AtmPin { get; set; }

        [Required(ErrorMessage = "Please enter new Atm Pin"), StringLength(4)]
        public string NewPin { get; set; }


    }
}
