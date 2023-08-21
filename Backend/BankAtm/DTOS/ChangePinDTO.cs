using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class ChangePinDTO
    {

        [Required(ErrorMessage = "Please Enter Account Number"), MaxLength(16)]
        public long AccNum;

        [Required(ErrorMessage = "Please Enter Card No"), MaxLength(16)]
        public string CardNo { get; set; }

        [Required(ErrorMessage = "Please Enter Atm Pin"), MaxLength(4)]
        public int AtmPin { get; set; }

        [Compare("AtmPin",ErrorMessage ="Pin Mistmatch")]
        public int confirmPin { get; set; }


    }
}
