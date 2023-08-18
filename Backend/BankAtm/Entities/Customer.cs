using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BankAtm.Entities

{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName ="varchar")]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(40)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        [Required]
        [StringLength(25)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
    }
}
