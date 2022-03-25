using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Employees;
using System;
using System.Linq;

namespace RealEstateWebApp.Services.Employees
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

        public bool IsEmployee(string userId)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(BecomeEmployeeFormModel employee, string userId)
        {
            var role = data
               .Roles
               .FirstOrDefault(x => x.Name == "Employee");

            var user = data
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var isUserAlreadyEmployee = data
           .UserRoles
           .Any(e => e.UserId == user.Id && e.RoleId == role.Id);

            if (isUserAlreadyEmployee)
            {
                throw new ArgumentException("User is already a manager");
            }

            System.Threading.Tasks.Task.Run(async () =>
            {
                await userManager.AddToRoleAsync(user, role.Name);
            });

            var isdone = data
                .UserRoles
                .Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            data.SaveChanges();

        }
    }
}
