using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Properties;
using Xunit;
using static RealEstateWebApp.Tests.Data.Properties;
using static RealEstateWebApp.Tests.Data.PropertyTypes;
using static RealEstateWebApp.Tests.Data.Addresses;

namespace RealEstateWebApp.Tests.Controllers
{
    public class PropertiesControllerTests
    {
        [Fact]
        public void AddGetShouldBeForAuthorizedUsersAndReturnReturnView()
            => MyController<PropertiesController>
            .Instance()
            .Calling(c => c.Add())
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View();

        [Theory]
        [InlineData(
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIcxm1tSJphluNimxurlape3Q9nhLcX3_apA&usqp=CAU",
            "jwqioqjdkallshdkljas",
            2020,
            5,
            200,
            500000,
            "Altrincham Road",
            1)]
        public void AddPostShouldBeForAuthorizedUsersAndReturnRedirectWithValidModelState(
             string ImageUrl,
             string Description,
             int BuildingYear,
             int Floor,
             decimal SquareMeters,
             decimal Price,
             string AddressText,
             int PropertyTypeId)
            => MyController<PropertiesController>
            .Instance(c => c
            .WithData(TenProperties())
            .AndAlso()
            .WithData(TenPropertyTypes())
            .AndAlso()
            .WithData(TenAddresses()))
            .Calling(c => c.Add(new AddPropertyFormModel
            {
                ImageUrl = ImageUrl,
                Description = Description,
                BuildingYear = BuildingYear,
                Floor = Floor,
                SquareMeters = SquareMeters,
                Price = Price,
                AddressText = AddressText,
                PropertyTypeId = PropertyTypeId
            }))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .ValidModelState()
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("All");

        [Fact]
        public void AddPostShouldReturnViewWithInvalidModelState()
            => MyController<PropertiesController>
            .Instance()
            .Calling(c => c.Add(new AddPropertyFormModel()
            {

            }))
            .ShouldReturn()
            .View();

        [Fact]
        public void AllShouldReturnViewWithCorrectModel()
            => MyController<PropertiesController>
            .Instance()
            .Calling(c => c.All(new AllPropertiesQueryModel
            {

            }))
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<AllPropertiesQueryModel>());

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void RemoveShouldBeForAuthorizedUsersAndReturnRedirectWithValidData(int id)
            => MyController<PropertiesController>
            .Instance()
            .WithData(TenProperties())
            .Calling(c => c.Remove(id))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .ValidModelState()
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("All");


        [Fact]
        public void RemoveShouldReturnErrorViewWithInvalidData()
            => MyController<PropertiesController>
            .Instance()
            .Calling(c => c.Remove(With.Any<int>()))
            .ShouldReturn()
            .View("Error");

        [Fact]
        public void DetailsShouldReturnViewWithCorrectModelWhenDataIsValid()
            => MyController<PropertiesController>
            .Instance()
            .WithData(TenProperties())
            .Calling(c => c.Details(1))
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<DetailsPropertyViewModel>());

        [Fact]
        public void DetailsShouldReturnErrorViewWithInvalidData()
            => MyController<PropertiesController>
            .Instance()
            .Calling(c => c.Details(1))
            .ShouldReturn()
            .View("Error");
    }
}
