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
            var user = data
                   .Users
                   .FirstOrDefault(x => x.Id == task.UserId);

            if (user == null)
            {
                throw new ArgumentException("User does not exist");
            }

            user.Tasks.Add(new Task()
            {
                Description = task.Description,
                UserId = user.Id
            });

            data.SaveChanges();

        }
    }
}
