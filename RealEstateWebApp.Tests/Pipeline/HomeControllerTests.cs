using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Home;
using Xunit;
using static RealEstateWebApp.Tests.Data.Properties;
namespace RealEstateWebApp.Tests.Pipeline
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
            => MyMvc
            .Pipeline()
            .ShouldMap("/")
            .To<HomeController>(c => c.Index())
            .Which(controller => controller
            .WithData(TenProperties())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<IndexViewModel>()));

        [Fact]
        public void PrivacyShouldReturnView()
            => MyMvc
            .Pipeline()
            .ShouldMap("/Home/Privacy")
            .To<HomeController>(c => c.Privacy())
            .Which()
            .ShouldReturn()
            .View();

        [Fact]
        public void AboutShouldReturnView()
            => MyMvc
            .Pipeline()
            .ShouldMap("/Home/About")
            .To<HomeController>(c => c.About())
            .Which()
            .ShouldReturn()
            .View();

        [Fact]
        public void ErrorShouldReturnView()
            => MyMvc
            .Pipeline()
            .ShouldMap("/Home/Error")
            .To<HomeController>(c => c.Error())
            .Which()
            .ShouldReturn()
            .View();

        [Fact]
        public void ContactShouldReturnView()
            => MyMvc
            .Pipeline()
            .ShouldMap("/Home/Contact")
            .To<HomeController>(c => c.Contact())
            .Which()
            .ShouldReturn()
            .View();
    }
}
