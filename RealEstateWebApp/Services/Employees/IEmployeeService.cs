using RealEstateWebApp.ViewModels.Employees;

namespace RealEstateWebApp.Services.Employees
{
    public interface IEmployeeService
    {
        public bool IsEmployee(string userId);

        public void CreateEmployee(BecomeEmployeeFormModel model, string userId);

    }
}
