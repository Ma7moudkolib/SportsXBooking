namespace Application.DataTransferObjects.Review
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int PlayerId { get; set; }
        public int PlaygroundId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
