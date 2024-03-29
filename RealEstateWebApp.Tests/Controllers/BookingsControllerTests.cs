﻿using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using Xunit;
using static RealEstateWebApp.Tests.Data.Bookings;
using static RealEstateWebApp.Tests.Data.Properties;

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
            .WithUser()
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
            .WithUser()
            .Calling(c => c.Book(With.Any<BookVisitFormModel>(), 50))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .ValidModelState()
            .AndAlso()
            .ShouldReturn()
            .View("Error");


        [Fact]
        public void EditBookingGetShouldBeForAuthorizedUsersAndReturnViewWithCorrectModel()
           => MyController<BookingsController>
            .Instance(c => c.WithData(TenProperties())
            .AndAlso()
            .WithData(Client())
            .AndAlso()
            .WithData(new Booking
            {
                ClientId = 1,
                Id = 1,
                Description = "some description",
                PropertyId = 1,
                VisitDate = new System.DateTime(),

            }))
            .Calling(c => c.EditBooking(1))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(v => v
            .WithModelOfType<EditBookingFormModel>());

        [Fact]
        public void EditBookingGetShouldReturnErrorViewWithIncorrectData()
            => MyController<BookingsController>
            .Instance()
            .Calling(c => c.EditBooking(With.Any<int>()))
            .ShouldReturn()
            .View("Error");

        [Fact]
        public void EditBookingPostShouldBeForAuthorizedUsersAndReturnRedirectToActionWithCorrectData()
            => MyController<BookingsController>
            .Instance()
            .WithData(new Booking
            {
                ClientId = 1,
                Id = 1,
                Description = "some description",
                PropertyId = 1,
                VisitDate = new System.DateTime(),

            })
            .Calling(c => c.EditBooking(new EditBookingFormModel()
            {
                BookingId = 1,
                Description = "changed description",
                VisitDate = "17.07.2022 17:30"
            }))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests()
            .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("AllBookings");

        [Fact]
        public void EditBookingPostShouldReturnErrorViewWithIncorrectData()
            => MyController<BookingsController>
            .Instance()
            .Calling(c => c.EditBooking(new EditBookingFormModel()
            {
                BookingId = 1,
                Description = "changed description",
                VisitDate = "17.07.2022 17:30"
            }))
            .ShouldHave()
            .ValidModelState()
            .AndAlso()
            .ShouldReturn()
            .View("Error");

        [Fact]
        public void DeleteBookingShouldBeForAuthorizedUsersAndReturnRedirectToActionWithCorrectData()
            => MyController<BookingsController>
            .Instance()
            .WithData(new Booking
            {
                ClientId = 1,
                Id = 1,
                Description = "some description",
                PropertyId = 1,
                VisitDate = new System.DateTime(),

            })
            .Calling(c => c.DeleteBooking(1))
            .ShouldHave()
            .ActionAttributes(attributes => attributes
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("AllBookings");

        [Fact]
        public void DeleteBookingsShouldReturnErrorViewWithIncorrectData()
            => MyController<BookingsController>
            .Instance()
            .Calling(c => c.DeleteBooking(With.Any<int>()))
            .ShouldReturn()
            .View("Error");
    }
}
