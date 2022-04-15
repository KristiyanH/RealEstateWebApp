using Xunit;
using MyTested.AspNetCore.Mvc;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.ViewModels.Bookings;

namespace RealEstateWebApp.Tests.Routing
{
    public class BookingsControllerTests
    {
        [Fact]
        public void BookGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Bookings/Book")
            .To<BookingsController>(c => c.Book());

        [Fact]
        public void BookPostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Bookings/Book")
            .WithMethod(HttpMethod.Post))
            .To<BookingsController>(c => c.Book(With.Any<BookVisitFormModel>(), With.Any<int>()));

        [Fact]
        public void AllBookingsRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Bookings/AllBookings")
            .To<BookingsController>(c => c.AllBookings());

        [Fact]
        public void EditBookingGetRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Bookings/EditBooking")
            .To<BookingsController>(c => c.EditBooking(With.Any<int>()));

        [Fact]
        public void EditBookingPostRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Bookings/EditBooking")
            .WithMethod(HttpMethod.Post))
            .To<BookingsController>(c => c.EditBooking(With.Any<EditBookingFormModel>()));

        [Fact]
        public void DeleteBookingRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Bookings/DeleteBooking")
            .To<BookingsController>(c => c.DeleteBooking(With.Any<int>()));
            
    }
}
