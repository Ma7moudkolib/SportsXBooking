using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects.Playground
{
    public class UpdatePlaygroundDto
    {
        public string Name { get; set; }
      
        public string Location { get; set; }
       
        public string SportType { get; set; }
        
        public decimal PricePerHour { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
