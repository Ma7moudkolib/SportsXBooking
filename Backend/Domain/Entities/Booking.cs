using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int PlaygroundId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled, Completed

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey("PlayerId")]
        public User Player { get; set; }

        [ForeignKey("PlaygroundId")]
        public Playground Playground { get; set; }

        public Payment Payment { get; set; }
    }
}
