using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.ViewModels
{
    public class BecomeEmployeeFormModel
    {
        [Required]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
