using RealEstateWebApp.Tests.Mocks;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;
using Xunit;

namespace RealEstateWebApp.Tests.Services
{
    public class PropertyServiceTests
    {
        [Fact]
        public void GetPropertyTypesShouldReturnTypes()
        {
            var propertyService = PropertyServiceMock.Instance;

            var result = propertyService.GetPropertyTypes();

            Assert.NotNull(result);
            Assert.IsType<List<PropertyTypeViewModel>>(result);
        }
    }
}
