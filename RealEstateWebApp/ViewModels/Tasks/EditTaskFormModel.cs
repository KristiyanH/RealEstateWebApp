using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;
namespace RealEstateWebApp.ViewModels.Tasks
{
    public class EditTaskFormModel
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        [StringLength(JobDescriptionMaxValue, MinimumLength = JobDescriptionMinValue)]
        public string Description { get; set; }
    }
}
