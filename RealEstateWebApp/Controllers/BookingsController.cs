using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Bookings;
using RealEstateWebApp.ViewModels.Bookings;

namespace RealEstateWebApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        public IActionResult Book()
            => View();

        [HttpPost]
        public IActionResult Book(BookVisitFormModel model, int propertyId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bookingService.Book(model, propertyId, User.GetId());

            return RedirectToAction("Index", "Home");
        }
    }
}
