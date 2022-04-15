using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using RealEstateWebApp.ViewModels.Properties;
using System;
using Xunit;

namespace RealEstateWebApp.Tests.Controllers
{
    public class BookingsControllerTests
    {
        [Fact]
        public void BookGetShouldBeForAuthorizedUsersAndReturnReturnView()
           => MyController<BookingsController>
           .Instance()
           .Calling(c => c.Book())
           .ShouldHave()
           .ActionAttributes(attributes => attributes
           .RestrictingForAuthorizedRequests())
           .AndAlso()
           .ShouldReturn()
           .View();

        [Theory]
        [InlineData(
            "Kristiyan Hristov",
            "0876065511",
            "kristiyan.a.hristov@gmail.com",
            "17.07.2022 17:30",
            "Any Description",
            2
            )]
        public void BookPostShouldBeForAuthorizedUsersAndWithCorrectData(string fullName,
            string phoneNumber,
            string email,
            string visitDate,
            string description,
            int propertyId)
            => MyController<BookingsController>
            .Instance()
            .Calling(c => c.Book(new BookVisitFormModel()
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Email = email,
                VisitDate = visitDate,
                Description = description
            }, propertyId))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .ValidModelState();

        [Fact]

        public void BookPostShouldBeForAuthorizedUsersAndReturnErrorViewWitIncorrectData()
             => MyController<BookingsController>
            .Instance()
            .Calling(c => c.Book(With.Any<BookVisitFormModel>(), 50))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .ValidModelState()
            .AndAlso()
            .ShouldReturn()
            .View("Error");


    }
}
