using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BankAPI.Entites
{
    public class Customer
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50), RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only letters of the alphabet")]
        public string Name { get; set; }
        [Required, MaxLength(50), RegularExpression(@"^\b[\dA-Za-z\s\-\\]+\b$", ErrorMessage = "Only letters and numbers")]
        public string Address { get; set; }
        [MaxLength(40), RegularExpression(@"^\b[A-Za-z\s]+$", ErrorMessage = "Please only use names.")]
        public string? City { get; set; }
        [Required, StringLength(50)]
        public string? Email { get; set;}
        [Required, RegularExpression(@"\b\d{6}\b", ErrorMessage = "Six digits only")]
        public int Pincode { get; set;}
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
