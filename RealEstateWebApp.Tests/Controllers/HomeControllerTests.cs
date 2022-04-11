using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.Tests.Mocks;
using RealEstateWebApp.ViewModels.Home;
using System;
using System.Linq;
using Xunit;

namespace RealEstateWebApp.Tests.Controllers
{
    public class HomeControllerTests : IDisposable
    {
        private readonly RealEstateDbContext data;
        private readonly IMapper mapper;
        private readonly HomeController homeController;
        public HomeControllerTests()
        {
            data = DatabaseMock.Instance;
            mapper = MapperMock.Instance;
            homeController = new HomeController(data, mapper);
            data.Properties.AddRange(Enumerable.Range(0, 5).Select(x => new Property()));
            data.SaveChanges();
        }

        public void Dispose()
        {
            data.Dispose();
        }

        [Fact]
        public void ErrorShouldReturnView()
        {
            var result = homeController.Error();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void PrivacyShouldReturnView()
        {
            var result = homeController.Privacy();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AboutShouldReturnView()
        {
            var result = homeController.About();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ContactShouldReturnView()
        {
            var result = homeController.Contact();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            var result = homeController.Index();

            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = viewResult.Model;

            Assert.IsType<IndexViewModel>(model);

        }

        [Fact]
        public void ConstructorShouldWorkAsExpected()
        {
            Assert.NotNull(homeController);
        }
    }
}
