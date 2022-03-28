using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Roles;
using RealEstateWebApp.ViewModels.Roles;
using System.Threading.Tasks;

namespace RealEstateWebApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService _roleService)
            => roleService = _roleService;

        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult CreateRole()
            => View();

        [HttpPost]
        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            roleService.CreateRole(model);

            return RedirectToAction("AllRoles", "Roles");
        }

        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult AllRoles()
        {
            return View(roleService.AllRoles());
        }

        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> EditRole(string id)
        {
            var model = await roleService.EditRoleGet(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await roleService.EditRolePost(model);

            return RedirectToAction("AllRoles", "Roles");
        }
    }
}
