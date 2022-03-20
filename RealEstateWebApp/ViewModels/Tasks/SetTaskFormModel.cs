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
        public int EmployeeId { get; set; }
    }
}
