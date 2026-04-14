using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Playground
    {
        [Key]
        public int PlaygroundId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        [Required]
        [MaxLength(50)]
        public string SportType { get; set; } // Football, Tennis, Basketball...

        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerHour { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }   // ✅ Single image column

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}

