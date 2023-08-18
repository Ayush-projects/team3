using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BankAPI.Entites
{
    public class Account
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNo { get; set; }
        [Required] //applies not null constraint
        public int AccountType { get; set; }
        [Required] //applies not null constraint
        public int Balance { get; set;}
        public int CardNo { get; set;}
        [Required, ForeignKey("CustomerId")]
        public int CustomerId { get; set;}
    }
}
