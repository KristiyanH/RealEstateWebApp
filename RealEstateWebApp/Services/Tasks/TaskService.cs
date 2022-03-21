using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Tasks;
using System;
using System.Linq;

namespace RealEstateWebApp.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly RealEstateDbContext data;

        public TaskService(RealEstateDbContext _data)
        {
            data = _data;
        }

        public void SetTask(SetTaskFormModel task)
        {
            var employee = data
                   .Employees
                   .FirstOrDefault(e => e.Id == task.EmployeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist");
            }

            employee.Tasks.Add(new Task()
            {
                Description = task.Description,
                EmployeeId = employee.Id
            });

            data.SaveChanges();

        }
    }
}
