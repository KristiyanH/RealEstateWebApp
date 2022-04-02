using RealEstateWebApp.Data;
using RealEstateWebApp.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly RealEstateDbContext data;

        public UserService(RealEstateDbContext _data)
        {
            data = _data;
        }

        public List<AllUsersViewModel> AllUsers()
        {
            var model = data.Users
                .Select(x => new AllUsersViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName
                }).ToList();

            return model;
        }
    }
}
