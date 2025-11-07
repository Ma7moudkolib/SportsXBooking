namespace Application.DataTransferObjects.Playground
{
    public class GetPlaygroundDto
    {
        public int PlaygroundId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string SportType { get; set; }
        public decimal PricePerHour { get; set; }
        public string ImageUrl { get; set; }
    }
}
