using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RealEstateWebApp.Data.DataConstants;

namespace RealEstateWebApp.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(AddressTextMaxLength)]
        public string AddressText { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }
    }
}
