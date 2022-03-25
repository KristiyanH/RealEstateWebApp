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
            Tasks = new List<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxValue)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxValue)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public int? ManagerId { get; set; }

        public Manager Manager { get; set; }

        public ICollection<Property> Properties { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
