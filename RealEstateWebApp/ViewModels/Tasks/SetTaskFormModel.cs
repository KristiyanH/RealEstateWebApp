using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;
namespace RealEstateWebApp.ViewModels.Tasks
{
    public class SetTaskFormModel
    {
        [Required]
        [StringLength(JobDescriptionMaxValue, MinimumLength = JobDescriptionMinValue)]
        public string Description { get; set; }

        [Required]
        [StringLength(36, MinimumLength = 36, ErrorMessage = "Valid ID is required.")]
        [Display(Name = "Employee ID")]
        public string UserId { get; set; }
    }
}
