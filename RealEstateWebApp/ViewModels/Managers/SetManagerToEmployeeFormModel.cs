using System.ComponentModel.DataAnnotations;
namespace RealEstateWebApp.ViewModels.Managers
{
    public class SetManagerToEmployeeFormModel
    {
        [Required]
        public int ManagerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
