using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Roles;
using RealEstateWebApp.ViewModels.Roles;

namespace RealEstateWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IRoleService roleService;

        public AdministrationController(IRoleService _roleService)
            => roleService = _roleService;
        

        public IActionResult CreateRole()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            roleService.CreateRole(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
