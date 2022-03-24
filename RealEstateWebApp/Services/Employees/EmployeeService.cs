using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Employees;
using System;
using System.Linq;

namespace RealEstateWebApp.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RealEstateDbContext data;

        public EmployeeService(RealEstateDbContext _data)
        {
            data = _data;
        }

        public bool IsEmployee(string userId)
            => data
            .Employees
            .Any(e => e.UserId == userId);

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
