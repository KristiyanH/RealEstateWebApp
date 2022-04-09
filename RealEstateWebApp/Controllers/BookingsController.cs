using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Bookings;
using RealEstateWebApp.ViewModels.Bookings;
using System;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly RealEstateDbContext data;
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService _bookingService,
            RealEstateDbContext _data)
        {
            bookingService = _bookingService;
            data = _data;
        }

        [Authorize]
        public IActionResult Book()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult Book(BookVisitFormModel model, int propertyId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                bookingService.Book(model, propertyId, User.GetId());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [Authorize]
        public IActionResult AllBookings()
        {
            var bookings = bookingService.AllBookings();

            return View(bookings);
        }
    }
}
