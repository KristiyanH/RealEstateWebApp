using Xunit;
using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Properties;

namespace RealEstateWebApp.Tests.Pipeline
{
    public class PropertiesControllerTests
    {
        [Fact]
        public void GetAddShouldBeForAuthorizedUsersAndReturnViewWithCorrectModel()
            => MyMvc
            .Pipeline()
            .ShouldMap(request => request
            .WithPath("/Properties/Add")
            .WithUser())
            .To<PropertiesController>(c => c.Add())
            .Which()
            .ShouldHave()
            .ActionAttributes(a => a
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<AddPropertyFormModel>());
    }
}
