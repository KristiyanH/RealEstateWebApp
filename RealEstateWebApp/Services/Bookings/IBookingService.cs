using RealEstateWebApp.ViewModels.Bookings;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Bookings
{
    public interface IBookingService
    {
        public void Book(BookVisitFormModel model, int propertyId, string userId);

        public List<AllBookingsViewModel> AllBookings();
    }
}
