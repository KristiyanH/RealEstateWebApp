using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.Property;
using static RealEstateWebApp.ErrorConstants;
namespace RealEstateWebApp.ViewModels.Properties
{
    using static Data.DataConstants;

    public class AddPropertyFormModel
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
        [Range(FloorMinValue, FloorMaxValue, ErrorMessage = FloorErrorMessage)]
        public int Floor { get; init; }

        [Required]
        [Range(SquareMetersMinValue, SquareMetersMaxValue, ErrorMessage = RequiredAndRangeErrorMessage)]
        public decimal SquareMeters { get; init; }

        [Required]
        public decimal Price { get; init; }

        [Required]
        [StringLength(AddressTextMaxLength)]
        [Display(Name = "Address")]
        public string AddressText { get; set; }

        [Required]
        [Display(Name = "Property Type")]
        public int PropertyTypeId { get; init; }

        public IEnumerable<PropertyTypeViewModel> PropertyTypes { get; set; }
    }
}
