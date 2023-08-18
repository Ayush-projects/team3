namespace BankAPI.DTOS
{
    public class TransactionDTO
    {
        public string TransID { get; set; }
        public int AccNum { get; set; }
        public string TransType { get; set; }
        public string TransDate { get; set; }
        public string TransTime { get; set; }

        public int Amount { get; set; }
    }
}