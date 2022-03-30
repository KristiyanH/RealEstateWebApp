using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels;
using System;
using System.Linq;

namespace RealEstateWebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<User> userManager;
        private readonly RealEstateDbContext data;

        public EmployeeService(RealEstateDbContext _data, UserManager<User> _userManager)
        {
            data = _data;
            userManager = _userManager;
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
    }
}
