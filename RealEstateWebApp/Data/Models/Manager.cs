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
        [StringLength(NameMaxValue, MinimumLength = NameMinValue)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
