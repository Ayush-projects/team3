﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAtm.Entities
{
    public class Account
    {
        // [Key]
        // public int SrNum { get; set; }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccNum { get; set; }

        [ForeignKey("Customer")]
        
        public int Id { get; set; }
        public virtual Customer? Customer { get; set; }//navigation prop
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string AccType{ get; set; }

        [Required]
        [StringLength(16)]
        public string CardNo { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string CardName { get; set; }

        [Required]
        public int Balance { get; set; }

        [Required]
        [StringLength(4)]
        public string AtmPin { get; set; }
        
        public int AccStatus { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
