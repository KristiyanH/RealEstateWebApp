using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Areas.Manager.Controllers;
using RealEstateWebApp.Controllers.Api;
using Xunit;

namespace RealEstateWebApp.Tests.Routing.Api
{
    public class PropertiesApiControllerTests
    {
        [Fact]
        public void GetPropertiesRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/api/properties")
            .To<PropertiesApiController>(c => c.GetProperties());

        [Fact]
        public void GetPropertyDetailsRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/api/properties/1")
            .To<PropertiesApiController>(c => c.GetPropertyDetails(1));
    }
}
