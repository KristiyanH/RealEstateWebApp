using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Roles
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; init; }

        [Required]
        public string RoleName { get; init; }

        public ICollection<string> Users { get; set; }
    }
}
