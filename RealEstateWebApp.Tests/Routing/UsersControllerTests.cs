using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Controllers;
using Xunit;

namespace RealEstateWebApp.Tests.Routing
{
    public class UsersControllerTests
    {
        [Fact]
        public void AllUsersRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Manager/Users/AllUsers")
            .To<UsersController>(c => c.AllUsers());
    }
}
