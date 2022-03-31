using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        [MinLength(2)]
        public string RoleName { get; init; }
    }
}
