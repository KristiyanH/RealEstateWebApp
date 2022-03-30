using RealEstateWebApp.ViewModels;

namespace RealEstateWebApp.Services
{
    public interface IEmployeeService
    {
        public void CreateEmployee(BecomeEmployeeFormModel model, string userId);

    }
}
