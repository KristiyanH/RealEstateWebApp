using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Infrastructure;
using RealEstateWebApp.Services.Bookings;
using RealEstateWebApp.ViewModels.Bookings;
using System;
using System.Linq;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
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

            if (User.IsManager() || User.IsEmployee())
            {
                return View(bookings);
            }

            return View(bookings.Where(x => x.Client.UserId == User.GetId()));
        }

        [Authorize(Roles = "Manager, Employee")]
        public IActionResult EditBooking(int bookingId)
        {
            try
            {
                var model = bookingService.EditBookingGet(bookingId);
                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;

                return View("Error");
            }
        }

        [Authorize(Roles = "Manager, Employee")]
        [HttpPost]
        public IActionResult EditBooking(EditBookingFormModel model)
        {
            try
            {
                bookingService.EditBookingPost(model);
                return RedirectToAction("AllBookings", "Bookings");
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;

                return View("Error");
            }
        }


    }
}
