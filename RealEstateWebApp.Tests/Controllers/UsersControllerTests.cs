using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Controllers;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using static RealEstateWebApp.Tests.Data.Users;
using Xunit;
using RealEstateWebApp.Areas.Manager.Models.Users;
using System.Collections.Generic;

namespace RealEstateWebApp.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public void UsersControllerShouldBeForAuthorizedUsers()
            => MyController<UsersController>
            .Instance()
            .ShouldHave()
            .Attributes(attributes => attributes
            .RestrictingForAuthorizedRequests());

        [Fact]
        public void AllUsersShouldReturnViewWithCorrectModel()
            => MyController<UsersController>
            .Instance()
            .WithData(TenUsers())
            .Calling(c => c.AllUsers())
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<List<AllUsersViewModel>>());
    }
}
