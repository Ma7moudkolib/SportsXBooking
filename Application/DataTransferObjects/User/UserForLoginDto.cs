using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects.User
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
