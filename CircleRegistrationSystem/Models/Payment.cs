using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RegistrationId { get; set; }

        [ForeignKey("RegistrationId")]
        public virtual Registration Registration { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; } // Cash, Card, Online

        [StringLength(20)]
        public string Status { get; set; } // Pending, Completed, Failed

        [StringLength(100)]
        public string TransactionId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Payment()
        {
            Id = Guid.NewGuid();
            PaymentDate = DateTime.Now;
            Status = "Pending";
            CreatedAt = DateTime.Now;
        }
    }
}