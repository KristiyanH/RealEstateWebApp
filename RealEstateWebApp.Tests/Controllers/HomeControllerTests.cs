using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.Tests.Mocks;
using RealEstateWebApp.ViewModels.Home;
using System.Linq;
using Xunit;

namespace RealEstateWebApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            var homeController = new HomeController(null, Mock.Of<IMapper>());

            var result = homeController.Error();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void PrivacyShouldReturnView()
        {
            var homeController = new HomeController(null, Mock.Of<IMapper>());

            var result = homeController.Privacy();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AboutShouldReturnView()
        {
            var homeController = new HomeController(null, Mock.Of<IMapper>());

            var result = homeController.About();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ContactShouldReturnView()
        {
            var homeController = new HomeController(null, Mock.Of<IMapper>());

            var result = homeController.Contact();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            data.Properties.AddRange(Enumerable.Range(0, 10).Select(x => new Property()));
            data.SaveChanges();

            Assert.NotNull(data.Properties);
            Assert.Equal(10, data.Properties.Count());

            var homeController = new HomeController(data, mapper);

            var result = homeController.Index();

            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = viewResult.Model;

            Assert.IsType<IndexViewModel>(model);

        }

        [Fact]
        public void ConstructorShouldWorkAsExpected()
        {
            var homeController = new HomeController(null, Mock.Of<IMapper>());

            Assert.NotNull(homeController);
        }
    }
}
