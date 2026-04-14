using System.ComponentModel.DataAnnotations;
namespace Application.DataTransferObjects.Playground
{
    public class CreatePlaygroundDto
    {
        [Required]
        public int OwnerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string SportType { get; set; }
        [Required]
        public decimal PricePerHour { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
