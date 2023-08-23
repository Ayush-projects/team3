using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BankAtm.Entities
{
    public class Transaction
    {

        // [Key]

        //  public int TId{ get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid TransID { get; set; }

        [ForeignKey("Account")]
        public long AccNum{ get; set; }
        public virtual Account? Account { get; set; }//navigation prop

        [Required]
        public long ToAccNum { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string TransType { get; set; }


        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public DateTime TransDateTime { get; set; }


        [Required]
        public int Amount { get; set; }
    }
}
