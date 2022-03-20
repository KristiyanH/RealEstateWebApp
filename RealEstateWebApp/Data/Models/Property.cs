using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RealEstateWebApp.Data.DataConstants.Property;
namespace RealEstateWebApp.Data.Models
{

    public class Property
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(BuildingYearMinValue, BuildingYearMaxValue)]
        public int BuildingYear { get; set; }

        [Required]
        [Range(FloorMinValue, FloorMaxValue)]
        public int Floor { get; set; }

        [Required]
        [Range(SquareMetersMinValue, SquareMetersMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SquareMeters { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PricePerSquareMeter
            => Price / SquareMeters;

        [Required]
        public int PropertyTypeId { get; init; }

        public PropertyType PropertyType { get; init; }

        [Required]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public int EmployeeId { get; init; }

        public Employee Employee { get; init; }
    }
}
