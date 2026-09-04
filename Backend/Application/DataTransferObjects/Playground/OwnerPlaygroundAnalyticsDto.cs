namespace Application.DataTransferObjects.Playground
{
    public class OwnerPlaygroundAnalyticsDto
    {
        public int TotalBookings { get; set; }
        public int ConfirmedBookings { get; set; }
        public int PendingBookings { get; set; }
        public int CancelledBookings { get; set; }
        public decimal CancellationRate { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal ConfirmedRevenue { get; set; }
        public List<PlaygroundPerformanceDto> PlaygroundStats { get; set; } = new();
        public List<BookingsByMonthDto> BookingsByMonth { get; set; } = new();
    }

    public class PlaygroundPerformanceDto
    {
        public int PlaygroundId { get; set; }
        public string PlaygroundName { get; set; }
        public string SportType { get; set; }
        public int TotalBookings { get; set; }
        public int ConfirmedBookings { get; set; }
        public int CancelledBookings { get; set; }
        public decimal Revenue { get; set; }
    }

    public class BookingsByMonthDto
    {
        public string Month { get; set; }
        public int Count { get; set; }
        public decimal Revenue { get; set; }
    }
}
