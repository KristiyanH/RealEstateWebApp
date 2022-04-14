using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.Data.Models
{
    public class Client
    {
        public Client()
        {
            Bookings = new List<Booking>();
        }

        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxValue)]
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string UserId { get; init; }

        public User User { get; init; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
