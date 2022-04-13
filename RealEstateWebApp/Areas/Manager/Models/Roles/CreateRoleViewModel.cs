using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.Areas.Manager.Models.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Role Name")]
        public string RoleName { get; init; }
    }
}
