using Xunit;
using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Properties;

namespace RealEstateWebApp.Tests.Routing
{
    public class PropertiesControllerTests
    {
        [Fact]
        public void GetAddRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Properties/Add")
            .To<PropertiesController>(c => c.Add());

        [Fact]
        public void PostAddRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Properties/Add")
            .WithMethod(HttpMethod.Post))
            .To<PropertiesController>(c => c.Add(With.Any<AddPropertyFormModel>()));
    }
}
