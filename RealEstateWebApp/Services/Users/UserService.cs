using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Employees;
using RealEstateWebApp.ViewModels.Managers;
using System;
using System.Linq;

namespace RealEstateWebApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly RealEstateDbContext data;

        public UserService(RealEstateDbContext _data)
        {
            data = _data;
        }

        public void CreateEmployee(BecomeEmployeeFormModel employee, string userId)
        {
            var isUserAlreadyEmployee = data
                .Employees
                .Any(e => e.UserId == userId);

            if (isUserAlreadyEmployee)
            {
                throw new ArgumentException("User is already an employee");
            }

            var employeeData = new Employee
            {
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                UserId = userId
            };

            data.Employees.Add(employeeData);
            data.SaveChanges();

        }

        public void CreateManager(BecomeManagerFormModel manager, string userId)
        {
            var isUserAlreadyManager = data
               .Managers
               .Any(m => m.UserId == userId);

            if (isUserAlreadyManager)
            {
                throw new ArgumentException("User is already a manager");
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
        }

        public void SetManagerToEmployee(SetManagerToEmployeeFormModel model)
        {
            var manager = data
                .Managers
                .FirstOrDefault(x => x.Id == model.ManagerId);

            if (manager == null)
            {
                throw new ArgumentException("User is not manager or does not exist");
            }

            var employee = data
                .Employees
                .FirstOrDefault(x => x.Id == model.EmployeeId);

            if (employee == null)
            {
                throw new ArgumentException("User is not employee or does not exist");
            }

            employee.ManagerId = model.ManagerId;
            manager.Employees.Add(employee);
            data.SaveChanges();
        }
    }
}
