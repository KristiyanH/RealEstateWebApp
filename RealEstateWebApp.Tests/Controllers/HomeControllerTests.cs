using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateWebApp.Controllers;
using Xunit;

namespace RealEstateWebApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            var homeController = new HomeController(null, null, Mock.Of<IMapper>());

            var result = homeController.Error();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
