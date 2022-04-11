using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.Tests.Mocks;
using RealEstateWebApp.ViewModels.Properties;
using System.Linq;
using Xunit;

namespace RealEstateWebApp.Tests.Controllers
{
    public class PropertiesControllerTests
    {
        [Fact]
        public void ConstructorShouldWorkAsExpected()
        {
            var propertiesController = new PropertiesController(null, Mock.Of<IPropertyService>());

            Assert.NotNull(propertiesController);
        }

        [Fact]
        public void AddShouldReturnViewWithCorrectModel()
        {
            var data = DatabaseMock.Instance;
            var propertyService = Mock.Of<IPropertyService>();

            var propertiesController = new PropertiesController(data, propertyService);

            var result = propertiesController.Add();

            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            
            var model = viewResult.Model;

            Assert.NotNull(model);
            Assert.IsType<AddPropertyFormModel>(model);
        }

        [Fact]
        public void AllShouldReturnViewWithCorrectModel()
        {
            var data = DatabaseMock.Instance;
            var propertyService = PropertyServiceMock.Instance;

            var types = propertyService.GetPropertyTypes();

            var propertiesController = new PropertiesController(data, propertyService);
            var query = Mock.Of<AllPropertiesQueryModel>();

            var result = propertiesController.All(query);

            Assert.NotNull(result);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = viewResult.Model;

            Assert.Null(model);
        }

        [Fact]
        public void DetailsShouldReturnViewWithCorrectModel()
        {
            var data = DatabaseMock.Instance;
            var propertyService = PropertyServiceMock.Instance;

            data.Properties.AddRange(Enumerable.Range(0, 1).Select(x => new Property()));
            data.SaveChanges();

            Assert.NotNull(data.Properties);
            Assert.Equal(1, data.Properties.Count());

            var propertiesController = new PropertiesController(data, propertyService);

            var result = propertiesController.Details(1);

            Assert.NotNull(result);

            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
