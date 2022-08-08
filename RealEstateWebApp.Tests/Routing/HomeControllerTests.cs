using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using Xunit;

namespace RealEstateWebApp.Tests.Routing
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/")
            .To<HomeController>(c => c.Index());

        [Fact]
        public void AboutRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Home/About")
            .To<HomeController>(c => c.About());

        [Fact]
        public void ErrorRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Home/Error")
            .To<HomeController>(c => c.Error());

        [Fact]
        public void ContactRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Home/Contact")
            .To<HomeController>(c => c.Contact());
    }
}
