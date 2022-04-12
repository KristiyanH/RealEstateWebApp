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

        [Fact]
        public void AllRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Properties/All")
            .To<PropertiesController>(c => c.All(With.Any<AllPropertiesQueryModel>()));

        [Fact]
        public void RemoveRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Properties/Remove")
            .To<PropertiesController>(c => c.Remove(With.Any<int>()));

        [Fact]
        public void DetailsRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Properties/Details")
            .To<PropertiesController>(c => c.Details(With.Any<int>()));
    }
}
