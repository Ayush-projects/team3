using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class TransactionDTO
    {
        [Required(ErrorMessage ="Please enter Account No")]
        public long AccNum1 { get; set; }
        [Required(ErrorMessage = "Please enter Transaction type")]
        public string TransType { get; set; }
        [Required(ErrorMessage = "Please enter payee account no")]
        public long AccNum2 { get; set; }
        [Required(ErrorMessage = "Please enter Amount")]
        public int Amount { get; set; }
    }
}
