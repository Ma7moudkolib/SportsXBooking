using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Required, EmailAddress, MaxLength(100)]
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //[Required]
        //public string PasswordHash { get; set; }
        [Required, MaxLength(20)]
        public string Role { get; set; } // Player, Owner, Admin

        // Navigation
        public ICollection<Playground> Playgrounds { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
