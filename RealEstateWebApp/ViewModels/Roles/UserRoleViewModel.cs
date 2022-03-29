using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Roles
{
    public class UserRoleViewModel
    {
        [Required]
        public string UserId { get; init; }

        [Required]
        public string UserName { get; init; }

        public bool IsSelected { get; set; }
    }
}
