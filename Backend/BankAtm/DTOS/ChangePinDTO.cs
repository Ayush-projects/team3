using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class ChangePinDTO
    {

        [Required(ErrorMessage = "Please Enter Account Number")]
        public long AccNum { get; set; }

        [Required(ErrorMessage = "Please Enter Card No"), MaxLength(16)]
        public string CardNo { get; set; }

        [Required(ErrorMessage = "Please old enter Atm Pin"), MaxLength(4)]
        public string AtmPin { get; set; }

        [Required(ErrorMessage = "Please old enter Atm Pin"), MaxLength(4)]
        public string NewPin { get; set; }


    }
}
