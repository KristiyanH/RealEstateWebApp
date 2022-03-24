using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Managers;
using System;
using System.Linq;

namespace RealEstateWebApp.Services.Managers
{
    public class ManagerService : IManagerService
    {
        private readonly RealEstateDbContext data;

        public ManagerService(RealEstateDbContext _data)
        {
            data = _data;
        }

        public bool IsManager(string userId)
            => data
            .Managers
            .Any(e => e.UserId == userId);

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
