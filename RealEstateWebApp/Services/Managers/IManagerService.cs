using RealEstateWebApp.ViewModels.Managers;

namespace RealEstateWebApp.Services.Managers
{
    public interface IManagerService
    {
        public void CreateManager(BecomeManagerFormModel model, string userId);

        public void SetManagerToEmployee(SetManagerToEmployeeFormModel model);
    }
}
