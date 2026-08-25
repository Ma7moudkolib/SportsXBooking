using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace Application.DataTransferObjects.Playground
{
    public class CreatePlaygroundDto
    {
        [Required]
        public int OwnerId { get; set; }

        [Required(ErrorMessage ="Name Of Playground is required. ")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Location is required. ")]
        public string Location { get; set; }
        [Required]
        public string SportType { get; set; }
        [Required(ErrorMessage = "Price is required. ")]
        
        public decimal PricePerHour { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public IFormFile Image { get; set; }
    }
}
