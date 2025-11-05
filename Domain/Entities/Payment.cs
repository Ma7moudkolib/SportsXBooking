using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    // Payment Entity
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } // CreditCard, DebitCard, Cash, MobilePayment

        [Required]
        [MaxLength(20)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded

        [MaxLength(100)]
        public string TransactionId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        // Navigation Property
        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
    }
}
