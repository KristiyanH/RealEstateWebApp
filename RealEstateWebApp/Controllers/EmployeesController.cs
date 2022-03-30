using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services;
using RealEstateWebApp.ViewModels;

namespace RealEstateWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(
            IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
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

            employeeService.CreateEmployee(employee, User.GetId());

            return RedirectToAction("All", "Properties");
        }
       
    }
}
