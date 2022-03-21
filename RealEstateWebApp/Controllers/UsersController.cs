using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Users;
using RealEstateWebApp.ViewModels.Employees;
using RealEstateWebApp.ViewModels.Managers;

namespace RealEstateWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService _userService)
        {
            userService = _userService;
        }


        [Authorize]
        public IActionResult CreateEmployee()
          => View();

        [HttpPost]
        [Authorize]
        public IActionResult CreateEmployee(BecomeEmployeeFormModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            userService.CreateEmployee(employee, User.GetId());
            
            return RedirectToAction("All", "Properties");
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

            userService.CreateManager(manager, User.GetId());

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

            userService.SetManagerToEmployee(model);

            return RedirectToAction("All", "Properties");
        }
    }
}
