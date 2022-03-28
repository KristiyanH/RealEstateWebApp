using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; init; }
    }
}
