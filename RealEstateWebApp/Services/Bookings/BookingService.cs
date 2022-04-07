using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using System;
using System.Globalization;
using System.Linq;

namespace RealEstateWebApp.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly RealEstateDbContext data;

        public BookingService(RealEstateDbContext _data)
        {
            data = _data;
        }

        public void Book(BookVisitFormModel model, int propertyId, string userId)
        {
            var user = data.Users
                .FirstOrDefault(x => x.Id == userId);

            var client = new Client
            {
                UserId = userId,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            data.Clients.Add(client);

            DateTime date;

            DateTime.TryParseExact(
                model.VisitDate, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            var booking = new Booking
            {
                ClientId = client.Id,
                Description = model.Description,
                PropertyId = propertyId,
                VisitDate = date
            };

            client.Bookings.Add(booking);
            data.SaveChanges();
        }
    }
}
