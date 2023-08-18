using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BankAPI.Entites;

namespace BankAPI.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar")]
        public string TransID { get; set; }

        [ForeignKey("Account")]
        public int AccNum { get; set; }
        public Account? Account { get; set; }//navigation prop

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string TransType { get; set; }


        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string TransDate { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string TransTime { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}