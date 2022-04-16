using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers.Api;
using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using Xunit;
using static RealEstateWebApp.Tests.Data.Properties;
namespace RealEstateWebApp.Tests.Controllers.Api
{
    public class PropertiesApiControllerTests
    {
        [Fact]
        public void GetPropertiesShouldReturnListOfCorrectModel()
            => MyController<PropertiesApiController>
            .Instance()
            .WithData(TenProperties())
            .Calling(c => c.GetProperties())
            .ShouldReturn()
            .ResultOfType<IEnumerable<Property>>();

        [Fact]
        public void GetPropertyDetailsShouldReturnCorrectModel()
            => MyController<PropertiesApiController>
            .Instance()
            .WithData(TenProperties())
            .Calling(c => c.GetPropertyDetails(1))
            .ShouldReturn()
            .ResultOfType<Property>();
    }
}
