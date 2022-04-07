using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;
using static RealEstateWebApp.ErrorConstants;
namespace RealEstateWebApp.ViewModels.Bookings
{
    public class BookVisitFormModel
    {
        [Required]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage = RequiredAndRangeErrorMessage)]
        public string FullName { get; init; }

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue, ErrorMessage = RequiredAndRangeErrorMessage)]
        public string PhoneNumber { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string VisitDate { get; set; }

        public string Description { get; init; }
    }
}
