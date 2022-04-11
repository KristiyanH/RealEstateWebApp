using AutoMapper;
using Moq;
using RealEstateWebApp.Controllers;
using RealEstateWebApp.Services.Bookings;
using Xunit;

namespace RealEstateWebApp.Tests.Controllers
{
    public class BookingsControllerTests
    {
        [Fact]
        public void ConstructorShouldWorkAsExpected()
        {
            var bookingsController = new BookingsController(Mock.Of<IBookingService>());

            Assert.NotNull(bookingsController);
        }

    }
}
