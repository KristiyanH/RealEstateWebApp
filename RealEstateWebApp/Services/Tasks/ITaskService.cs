using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Tasks;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Tasks
{
    public interface ITaskService
    {
        public void SetTask(SetTaskFormModel model);

        public void CompleteTask(int taskId, string userId);

        public void EditTask(EditTaskFormModel model);

        public IEnumerable<Task> GetAllTasks();

        public IEnumerable<Task> GetAllTasksForUser(string userId);
    }
}
