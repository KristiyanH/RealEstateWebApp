using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly RealEstateDbContext data;

        public TaskService(RealEstateDbContext _data)
            => data = _data;

        public void SetTask(SetTaskFormModel task)
        {
            var user = GetUser(task.UserId);

            user.Tasks.Add(new Task()
            {
                Description = task.Description,
                UserId = user.Id
            });

            data.SaveChanges();
        }

        public void CompleteTask(int taskId, string userId)
        {
            var task = GetTask(taskId);

            task.IsCompleted = true;
            RemoveTaskFromUser(userId, task);

            data.SaveChanges();
        }

        public void EditTask(EditTaskFormModel model)
        {
            var task = GetTask(model.TaskId);

            task.Description = model.Description;
            data.SaveChanges();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return data.Tasks.ToList();
        }

        public IEnumerable<Task> GetAllTasksForUser(string userId)
        {
            return data.Tasks.Where(x => x.UserId == userId);
        }

        private void RemoveTaskFromUser(string userId, Task task)
        {
            var user = GetUser(userId);

            user.Tasks.Remove(task);
        }

        private User GetUser(string userId)
        {
            var user = data
               .Users
               .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(NotExistingUserErrorMessage, userId));
            }

            return user;
        }

        private Task GetTask(int taskId)
        {
            var task = data
                .Tasks
                .FirstOrDefault(x => x.Id == taskId);

            if (task == null)
            {
                throw new ArgumentNullException(string.Format(NotExistingTaskErrorMessage, taskId));
            }

            return task;
        }
    }
}
