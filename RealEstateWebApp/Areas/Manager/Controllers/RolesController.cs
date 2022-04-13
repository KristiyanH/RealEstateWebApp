using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Models.Roles;
using RealEstateWebApp.Services.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static RealEstateWebApp.ErrorConstants;
using static RealEstateWebApp.WebConstants;
namespace RealEstateWebApp.Areas.Admin.Controllers
{
    [Area(ManagerRoleName)]
    [Authorize(Roles = ManagerRoleName)]
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService _roleService)
            => roleService = _roleService;

        public IActionResult CreateRole()
            => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await roleService.CreateRole(model);

            return RedirectToAction("AllRoles", "Roles");
        }

        public IActionResult AllRoles()
        {
            return View(roleService.AllRoles());
        }

        public async Task<IActionResult> EditRole(string id)
        {
            try
            {
                var model = await roleService.EditRoleGet(id);

                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;
                return View("Error");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await roleService.EditRolePost(model);

            return RedirectToAction("AllRoles", "Roles");

        }

        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewData["RoleId"] = roleId;

            try
            {
                var model = await roleService.EditUsersInRoleGet(roleId);

                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;
                return View("Error");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Count == 0)
            {
                return RedirectToAction("EditRole", new { Id = roleId });
            }

            await roleService.EditUsersInRolePost(model, roleId);

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            try
            {
                await roleService.DeleteRole(id);

                return RedirectToAction("AllRoles", "Roles");
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;
                return View("Error");
            }
        }
    }
}
