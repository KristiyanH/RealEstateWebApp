using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants;

namespace RealEstateWebApp.Data.Models
{
    public class Address
    {
        public Address()
        {
            Properties = new List<Property>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AddressTextMaxLength)]
        public string AddressText { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
