using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Home;
using Xunit;
using static RealEstateWebApp.Tests.Data.Properties;

namespace RealEstateWebApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionShouldReturnCorrectViewWithModel()
            => MyController<HomeController>
            .Instance(c => c
            .WithData(TenProperties()))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<IndexViewModel>());

        [Fact]
        public void PrivacyShouldReturnView()
            => MyController<HomeController>
            .Instance()
            .Calling(c => c.Privacy())
            .ShouldReturn()
            .View();

        [Fact]
        public void AboutShouldReturnView()
            => MyController<HomeController>
            .Instance()
            .Calling(c => c.About())
            .ShouldReturn()
            .View();

        [Fact]
        public void ErrorShouldReturnView()
            => MyController<HomeController>
            .Instance()
            .Calling(c => c.Error())
            .ShouldReturn()
            .View();

        [Fact]
        public void ContactShouldReturnView()
            => MyController<HomeController>
            .Instance()
            .Calling(c => c.Contact())
            .ShouldReturn()
            .View();
    }
}
