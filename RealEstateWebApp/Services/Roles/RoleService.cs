using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Roles;
using System;
using System.Collections.Generic;
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

        public async System.Threading.Tasks.Task CreateRole(CreateRoleViewModel model)
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
                throw new ArgumentException($"Role with id:{id} not found!");
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
                throw new ArgumentException($"Role with id:{model.Id} not found!");
            }
            else
            {
                role.Name = model.RoleName;
                await roleManager.UpdateAsync(role);
            }
        }

        public async System.Threading.Tasks.Task<List<UserRoleViewModel>> EditUsersInRoleGet(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                throw new ArgumentException($"Role with id:{roleId} not found!");
            }

            var userRoles = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                userRoles.Add(userRoleViewModel);
            }

            return userRoles;
        }

        public async System.Threading.Tasks.Task EditUsersInRolePost(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                throw new ArgumentException($"Role with id:{roleId} not found!");
            }

            for (int i = 0; i < model.Count; i++)
            {
               var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public async System.Threading.Tasks.Task DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                throw new ArgumentException($"Role with id:{id} not found!");
            }

            await roleManager.DeleteAsync(role);
        }
    }
}
