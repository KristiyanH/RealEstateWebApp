using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.ViewModels.Roles;
using System.Threading.Tasks;

namespace RealEstateWebApp.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleService(RoleManager<IdentityRole> _roleManager)
            => roleManager = _roleManager;

        public void CreateRole(CreateRoleViewModel model)
        {
            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(model.RoleName))
                {
                    return;
                }
                var identityRole = new IdentityRole{Name = model.RoleName};
                await roleManager.CreateAsync(identityRole);
            })
                .GetAwaiter()
                .GetResult();
        }
    }
}
