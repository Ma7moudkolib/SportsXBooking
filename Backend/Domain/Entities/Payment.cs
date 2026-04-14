using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required, MaxLength(30)]
        public string PaymentMethod { get; set; } // Cash, CreditCard, Wallet...

        [Required, MaxLength(20)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Paid, Failed

        [MaxLength(100)]
        public string TransactionId { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
    }
}
