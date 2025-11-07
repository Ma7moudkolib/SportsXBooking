using System.ComponentModel.DataAnnotations;
namespace Application.DataTransferObjects.User
{
    public class UpdateUserDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "Player";
    }
}
