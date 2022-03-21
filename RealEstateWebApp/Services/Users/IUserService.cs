using RealEstateWebApp.ViewModels.Employees;
using RealEstateWebApp.ViewModels.Managers;

namespace RealEstateWebApp.Services.Users
{
    public interface IUserService
    {
        public void CreateEmployee(BecomeEmployeeFormModel model, string userId);

        public void CreateManager(BecomeManagerFormModel model, string userId);

        public void SetManagerToEmployee(SetManagerToEmployeeFormModel model);
    }
}
