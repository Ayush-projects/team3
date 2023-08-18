using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankAPI.Models
{
    public class AccountModel
    {
        public int AccountNo { get; set; }
        public int AccountType { get; set; }
        public int Balance { get; set; }
        public int CardNo { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
