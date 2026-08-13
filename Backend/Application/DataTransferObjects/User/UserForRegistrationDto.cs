using System.ComponentModel.DataAnnotations;
namespace Application.DataTransferObjects.User
{
    public class UserForRegistrationDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "Player";
    }
}
