using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            Properties = new List<Property>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public ICollection<Property> Properties { get; init; }
    }
}
