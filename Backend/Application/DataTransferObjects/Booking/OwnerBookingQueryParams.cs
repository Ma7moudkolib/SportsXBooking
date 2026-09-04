namespace Application.DataTransferObjects.Booking
{
    public class OwnerBookingQueryParams
    {
        public int? PlaygroundId { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
