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

            return RedirectToAction("AllRoles", "Administration");
        }

        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult AllRoles()
        {
            return View(roleService.AllRoles());
        }

        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> EditRole(string id)
        {
            var model = await roleService.EditRole(id);

            return View(model);
        }
    }
}
