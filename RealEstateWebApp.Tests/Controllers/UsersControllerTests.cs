using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Controllers;
using RealEstateWebApp.Areas.Manager.Models.Users;
using System.Collections.Generic;
using Xunit;
using static RealEstateWebApp.Tests.Data.Users;

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
