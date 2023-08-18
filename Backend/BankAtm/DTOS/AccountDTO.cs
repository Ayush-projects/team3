using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class AccountDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Account Type"), MaxLength(20)]
        public string AccType { get; set; }
        [Required(ErrorMessage ="Please Enter Card No"), MaxLength(16)]
        public string CardNo { get; set; }
        [Required(ErrorMessage = "Please Enter Card Name"), MaxLength(20)]
        public string CardName { get; set; }
        [Required(ErrorMessage = "Please Enter Balance")]
        public int Balance { get; set; }
    }
}
