using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RealEstateWebApp.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly IMapper mapper;
        private readonly RealEstateDbContext data;

        public BookingService(RealEstateDbContext _data,
            IMapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        public void Book(BookVisitFormModel model, int propertyId, string userId)
        {
            var client = new Client
            {
                UserId = userId,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
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

        public List<AllBookingsViewModel> AllBookings()
        {
            var bookings = data
                .Bookings
                .ProjectTo<AllBookingsViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return bookings;
        }
    }
}
