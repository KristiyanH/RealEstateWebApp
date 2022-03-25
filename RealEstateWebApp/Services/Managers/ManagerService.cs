using Microsoft.AspNetCore.Identity;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Managers;
using System;
using System.Linq;

namespace RealEstateWebApp.Services.Managers
{
    public class ManagerService : IManagerService
    {
        private readonly UserManager<User> userManager;
        private readonly RealEstateDbContext data;

        public ManagerService(RealEstateDbContext _data, UserManager<User> _userManager)
        {
            data = _data;
            userManager = _userManager;
        }

        //public bool IsManager(string userId)
        //    => data
        //    .UserRoles
        //    .Any(e => e.UserId == userId);

        public void CreateManager(BecomeManagerFormModel manager, string userId)
        {
            var role = data
                .Roles
                .FirstOrDefault(x => x.Name == "Manager");

            var user = data
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var isUserAlreadyManager = data
           .UserRoles
           .Any(e => e.UserId == user.Id && e.RoleId == role.Id);

            if (isUserAlreadyManager)
            {
                throw new ArgumentException("User is already a manager");
            }

            System.Threading.Tasks.Task.Run(async () =>
            {
                await userManager.AddToRoleAsync(user, role.Name);
            });

            data.SaveChanges();
        }

        public bool IsManager(string userId)
        {
            throw new NotImplementedException();
        }

        //public void SetManagerToEmployee(SetManagerToEmployeeFormModel model)
        //{
        //    var manager = data
        //        .Managers
        //        .FirstOrDefault(x => x.Id == model.ManagerId);

        //    if (manager == null)
        //    {
        //        throw new ArgumentException("User is not manager or does not exist");
        //    }

        //    var employee = data
        //        .Employees
        //        .FirstOrDefault(x => x.Id == model.EmployeeId);

        //    if (employee == null)
        //    {
        //        throw new ArgumentException("User is not employee or does not exist");
        //    }

        //    employee.ManagerId = model.ManagerId;
        //    manager.Employees.Add(employee);
        //    data.SaveChanges();
        //}
    }
}
