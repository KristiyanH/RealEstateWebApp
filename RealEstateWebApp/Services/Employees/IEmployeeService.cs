using RealEstateWebApp.ViewModels.Employees;

namespace RealEstateWebApp.Services.Employees
{
    public interface IEmployeeService
    {
        public void CreateEmployee(BecomeEmployeeFormModel model, string userId);

    }
}
