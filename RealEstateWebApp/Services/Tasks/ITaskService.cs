using RealEstateWebApp.ViewModels.Tasks;

namespace RealEstateWebApp.Services.Tasks
{
    public interface ITaskService
    {
        public void SetTask(SetTaskFormModel model);

        public void CompleteTask(int taskId, string userId);

        public void EditTask(EditTaskFormModel model);
    }
}
