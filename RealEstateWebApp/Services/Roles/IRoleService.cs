using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.ViewModels.Roles;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebApp.Services.Roles
{
    public interface IRoleService
    {
        public void CreateRole(CreateRoleViewModel model);

        public IQueryable<IdentityRole> AllRoles();

        public Task<EditRoleViewModel> EditRoleGet(string id);

        public Task EditRolePost(EditRoleViewModel model);
    }
}
