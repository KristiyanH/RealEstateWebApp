using RealEstateWebApp.ViewModels.Bookings;

namespace RealEstateWebApp.Services.Bookings
{
    public interface IBookingService
    {
        public void Book(BookVisitFormModel model, int propertyId, string userId);
    }
}
