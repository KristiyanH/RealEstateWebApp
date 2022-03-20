using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.ViewModels.Managers
{
    public class BecomeManagerFormModel
    {
        [Required]
        [StringLength(NameMaxValue, MinimumLength = NameMinValue)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxValue, MinimumLength = PhoneNumberMinValue)]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [StringLength(JobDescriptionMaxValue, MinimumLength = JobDescriptionMinValue)]
        public string JobDescription { get; set; }
    }
}
