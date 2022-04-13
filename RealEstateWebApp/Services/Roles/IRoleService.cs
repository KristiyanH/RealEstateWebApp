using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.Areas.Manager.Models.Roles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebApp.Services.Roles
{
    public interface IRoleService
    {
        public Task CreateRole(CreateRoleViewModel model);

        public IQueryable<IdentityRole> AllRoles();

        public Task<EditRoleViewModel> EditRoleGet(string id);

        public Task EditRolePost(EditRoleViewModel model);

        public Task<List<UserRoleViewModel>> EditUsersInRoleGet(string roleId);

        public Task EditUsersInRolePost(List<UserRoleViewModel> model, string roleId);

        public Task DeleteRole(string id);
    }
}
