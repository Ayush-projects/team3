using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class AccountDetailsDTO
    {
        public long AccNum { get; set; }
        public int Id { get; set; }
        public string AccType { get; set; }
        public string CardNo { get; set; }
        public string CardName { get; set; }
        public int Balance { get; set; }
        public int AccStatus { get; set; }
        public string AtmPin { get; set; }
    }
}
