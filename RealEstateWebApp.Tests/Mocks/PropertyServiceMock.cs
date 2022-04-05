using Moq;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Mocks
{
    public static class PropertyServiceMock
    {
        public static IPropertyService Instance
        {
            get
            {
                var propertyServiceMock = new Mock<IPropertyService>();

                var propertyTypesMock = new[]
                {
                    new PropertyTypeViewModel{ Id=1, Name = "Apartment"},
                    new PropertyTypeViewModel{ Id=2, Name = "Villa"},
                    new PropertyTypeViewModel{ Id=3, Name = "House"},
                    new PropertyTypeViewModel{ Id=4, Name = "Mansion"},
                    new PropertyTypeViewModel{ Id=5, Name = "Residence"}
                }.ToList();

                propertyServiceMock
                    .Setup(x => x.GetPropertyTypes())
                    .Returns(propertyTypesMock);

                return propertyServiceMock.Object;
            }
        }
    }
}
