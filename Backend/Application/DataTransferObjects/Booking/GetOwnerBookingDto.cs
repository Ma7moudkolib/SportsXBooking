namespace Application.DataTransferObjects.Booking
{
    public class GetOwnerBookingDto
    {
        public int BookingId { get; set; }
        public int PlayerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int PlaygroundId { get; set; }
        public string PlaygroundName { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
