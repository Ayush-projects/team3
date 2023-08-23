using BankAtm.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class TransactionDetailsDTO
    {
        public Guid TransID { get; set; }

        public long AccNum { get; set; }
        
        public long ToAccNum { get; set; }

        public string TransType { get; set; }

        public DateTime TransDateTime { get; set; }

        public int Amount { get; set; }
    }
}
