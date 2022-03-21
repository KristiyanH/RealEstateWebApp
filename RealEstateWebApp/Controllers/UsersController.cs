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
        private readonly RealEstateDbContext data;
        private readonly IUserService userService;

        public UsersController(
            RealEstateDbContext _data,
            IUserService _userService)
        {
            data = _data;
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

            var userId = User.GetId();

            userService.CreateEmployee(employee, userId);
            
            return RedirectToAction("All", "Properties");
        }

        [Authorize]
        public IActionResult CreateManager()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult CreateManager(BecomeManagerFormModel manager)
        {
            var userId = User.GetId();

            if (!ModelState.IsValid)
            {
                return View(manager);
            }

            userService.CreateManager(manager, userId);

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
