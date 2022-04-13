using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.Areas.Manager.Models.Roles
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
