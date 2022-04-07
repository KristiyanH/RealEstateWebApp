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

            user.Tasks.Add(new Task()
            {
                Description = task.Description,
                UserId = user.Id
            });

            data.SaveChanges();
        }
        public void CompleteTask(int taskId, string userId)
        {
            var task = data
               .Tasks
               .FirstOrDefault(x => x.Id == taskId);

            var user = data
                .Users
                .FirstOrDefault(x => x.Id == userId);

            if (task == null)
            {
                throw new ArgumentException($"Task with id: {taskId} not found!");
            }

            if (user == null)
            {
                throw new ArgumentException($"User with id: {userId} not found!");
            }

            task.IsCompleted = true;
            user.Tasks.Remove(task);
            data.SaveChanges();
        }

        public void EditTask(EditTaskFormModel model)
        {
            var task = data
                .Tasks
                .FirstOrDefault(x => x.Id == model.TaskId);

            if (task == null)
            {
                throw new ArgumentException($"Task with id: {model.TaskId} not found!");
            }

            task.Description = model.Description;
            data.SaveChanges();
        }
    }
}
