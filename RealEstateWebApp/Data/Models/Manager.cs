using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.Data.Models
{
    public class Manager
    {
        public Manager()
        {
            Employees = new List<Employee>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxValue)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxValue)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxValue)]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [MaxLength(JobDescriptionMaxValue)]
        public string JobDescription { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
