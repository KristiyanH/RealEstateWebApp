using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Roles;
using RealEstateWebApp.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService _roleService)
            => roleService = _roleService;

        [Authorize(Roles = "Manager")]
        public IActionResult CreateRole()
            => View();

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await roleService.CreateRole(model);

            return RedirectToAction("AllRoles", "Roles");
        }

        [Authorize(Roles = "Manager")]
        public IActionResult AllRoles()
        {
            return View(roleService.AllRoles());
        }

        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await roleService.EditRolePost(model);

            return RedirectToAction("AllRoles", "Roles");

        }

        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
