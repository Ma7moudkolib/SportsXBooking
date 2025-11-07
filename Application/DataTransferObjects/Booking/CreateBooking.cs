using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects.Booking
{
    public class CreateBooking
    {
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
    }
}
