using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RealEstateWebApp.ViewModels.Properties
{
    using static Data.DataConstants;

    public class AddPropertyViewModel
    {
        public int Id { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; init; }

        [Required]
        [Range(BuildingYearMinValue, BuildingYearMaxValue, ErrorMessage = RequiredAndRangeErrorMessage)]
        public int BuildingYear { get; init; }

        [Required]
        [Range(PropertyFloorMinValue, PropertyFloorMaxValue, ErrorMessage = FloorErrorMessage)]
        public int Floor { get; init; }

        [Required]
        [Range(SquareMetersMinValue, SquareMetersMaxValue, ErrorMessage = RequiredAndRangeErrorMessage)]
        public decimal SquareMeters { get; init; }

        [Required]
        [Range(PropertyPriceMinValue, PropertyPriceMaxValue, ErrorMessage = RequiredAndRangeErrorMessage)]
        public decimal Price { get; init; }

        [Required]
        [Display(Name = "Address")]
        public string AddressText { get; set; }

        [Required]
        [Display(Name = "Property Type")]
        public int PropertyTypeId { get; init; }

        public IEnumerable<PropertyTypeViewModel> PropertyTypes { get; set; }
    }
}
