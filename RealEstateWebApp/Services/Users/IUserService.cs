using RealEstateWebApp.ViewModels.Users;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Users
{
    public interface IUserService
    {
        public List<AllUsersViewModel> AllUsers();
    }
}
