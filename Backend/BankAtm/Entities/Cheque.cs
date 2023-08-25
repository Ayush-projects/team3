using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAtm.Entities
{
    public class Cheque
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChequeNo { get; set; }

        [ForeignKey("Account")]
        public long AccNum { get; set; }

        public int amount{ get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string status { get; set; }

        [StringLength(12)]
        [Column(TypeName = "varchar")]
        public string TransDateTime { get; set; }
    }
}
