using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.ViewModels.Employees;
using RealEstateWebApp.ViewModels.Managers;
using RealEstateWebApp.ViewModels.Tasks;
using System.Linq;

namespace RealEstateWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly RealEstateDbContext data;
        public UsersController(RealEstateDbContext _data)
            => data = _data;

        [Authorize]
        public IActionResult CreateEmployee()
          => View();

        [HttpPost]
        [Authorize]
        public IActionResult CreateEmployee(BecomeEmployeeFormModel employee)
        {
            var userId = User.GetId();

            var isUserAlreadyEmployee = data
                .Employees
                .Any(e => e.UserId == userId);

            if (isUserAlreadyEmployee)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var employeeData = new Employee
            {
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                UserId = userId
            };

            data.Employees.Add(employeeData);
            data.SaveChanges();

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

            var isUserAlreadyManager = data
                .Managers
                .Any(m => m.UserId == userId);

            if (isUserAlreadyManager)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(manager);
            }

            var managerData = new Manager
            {
                Name = manager.Name,
                JobDescription = manager.JobDescription,
                PhoneNumber = manager.PhoneNumber,
                EmergencyContactNumber = manager.EmergencyContactNumber,
                UserId = userId
            };

            data.Managers.Add(managerData);
            data.SaveChanges();

            return RedirectToAction("All", "Properties");
        }

        [Authorize]
        public IActionResult SetTask()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult SetTask(SetTaskFormModel task)
        {
            if (!IsManager())
            {
                return RedirectToAction("Index", "Home");
            }

            var employee = data
                .Employees
                .FirstOrDefault(e => e.Id == task.EmployeeId);

            if (employee == null)
            {
                return BadRequest();
            }

            employee.Tasks.Add(new Task()
            {
                Description = task.Description,
                EmployeeId = employee.Id
            });

            data.SaveChanges();
            return RedirectToAction("All", "Properties");

        }

        private  bool IsManager()
        {
            var isUserManager = data
                .Managers
                .Any(m => m.UserId == User.GetId());

            return isUserManager;
        }
    }
}
