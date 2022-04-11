using AutoMapper;
using Moq;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.Tests.Mocks;
using RealEstateWebApp.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RealEstateWebApp.Tests.Services
{
    public class PropertyServiceTests : IDisposable
    {
        private readonly RealEstateDbContext data;
        private readonly IMapper mapper;
        private readonly IPropertyService propertyService;

        public PropertyServiceTests()
        {
            data = DatabaseMock.Instance;
            mapper = MapperMock.Instance;
            propertyService = new PropertyService(data, mapper);
            data.Properties.AddRange(Enumerable.Range(0, 5).Select(x => new Property()));
            data.SaveChanges();
        }

        public void Dispose()
        {
            data.Dispose();
        }

        [Fact]
        public void ConstructorShouldWorkAsExpected()
        {
            Assert.NotNull(propertyService);
        }

        [Fact]
        public void GetPropertyTypesShouldReturnTypes()
        {
            var result = propertyService.GetPropertyTypes();

            Assert.NotNull(result);
            Assert.IsType<List<PropertyTypeViewModel>>(result);
        }

        [Fact]
        public void RemoveShouldWorkAsExpected()
        {
            propertyService.Remove(1);
            Assert.Equal(4, data.Properties.Count());
        }

        [Fact]
        public void RemoveShouldThrowExceptionIfPropertyNotFound()
        {
            Action action = new Action(() => { propertyService.Remove(55); });

            var exception = Assert.Throws<ArgumentException>(action);
            var actualMessage = exception.Message;
            var expectedMessage = "Property with id:55 does not exist";

            Assert.Equal(actualMessage, expectedMessage);
        }
    }
}
