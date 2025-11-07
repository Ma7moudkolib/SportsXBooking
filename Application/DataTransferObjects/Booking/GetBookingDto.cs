namespace Application.DataTransferObjects.Booking
{
    public class GetBookingDto
    {
        public int BookingId { get; set; }
        public int PlayerId { get; set; }
        public int PlaygroundId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
