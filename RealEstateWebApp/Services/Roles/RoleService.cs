using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Roles;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebApp.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(RoleManager<IdentityRole> _roleManager,
            UserManager<User> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }


        public IQueryable<IdentityRole> AllRoles()
        {
            return roleManager.Roles;
        }

        public async void CreateRole(CreateRoleViewModel model)
        {
            if (await roleManager.RoleExistsAsync(model.RoleName))
            {
                return;
            }

            var identityRole = new IdentityRole { Name = model.RoleName };

            await roleManager.CreateAsync(identityRole);
        }

        public async Task<EditRoleViewModel> EditRoleGet(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                throw new ArgumentException($"View with id:{id} not found!");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return model;
        }

        public async System.Threading.Tasks.Task EditRolePost(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                throw new ArgumentException($"View with id:{model.Id} not found!");
            }
            else
            {
                role.Name = model.RoleName;
                await roleManager.UpdateAsync(role);
            }
        }
    }
}
