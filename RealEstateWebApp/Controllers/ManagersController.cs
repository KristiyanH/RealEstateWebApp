using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Managers;
using RealEstateWebApp.ViewModels.Managers;

namespace RealEstateWebApp.Controllers
{
    public class ManagersController : Controller
    {
        private readonly IManagerService managerService;

        public ManagersController(
            IManagerService _managerService)
        {
            managerService = _managerService;
        }

        [Authorize]
        public IActionResult CreateManager()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult CreateManager(BecomeManagerFormModel manager)
        {
            if (!ModelState.IsValid)
            {
                return View(manager);
            }

            managerService.CreateManager(manager, User.GetId());

            return RedirectToAction("All", "Properties");
        }

        [Authorize]
        public IActionResult SetManagerToEmployee()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult SetManagerToEmployee(SetManagerToEmployeeFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            managerService.SetManagerToEmployee(model);

            return RedirectToAction("All", "Properties");
        }
    }
}
