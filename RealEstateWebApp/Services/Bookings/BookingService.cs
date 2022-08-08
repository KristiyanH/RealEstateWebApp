using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static RealEstateWebApp.ErrorConstants;

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

        public List<AllBookingsViewModel> AllBookings() =>
            data
                .Bookings
                .ProjectTo<AllBookingsViewModel>(mapper.ConfigurationProvider)
                .ToList();

        public void Book(BookVisitFormModel model, int propertyId, string userId)
        {
            EnsurePropertyExists(propertyId);

            var client = data.Clients.FirstOrDefault(x => x.UserId == userId);

            if (client == null)
            {
                client = new Client
                {
                    UserId = userId,
                    Email = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber
                };

                data.Clients.Add(client);
            }

            AssignBookingToClient(client, model.VisitDate, model.Description, propertyId);
            data.SaveChanges();
        }

        public EditBookingFormModel EditBookingGet(int bookingId)
        {
            var booking = GetBooking(bookingId);

            var bookingModel = mapper.Map<EditBookingFormModel>(booking);

            return bookingModel;
        }

        public void EditBookingPost(EditBookingFormModel model)
        {
            var booking = GetBooking(model.BookingId);

            booking.VisitDate = ParseDate(model.VisitDate);
            booking.Description = model.Description;

            data.SaveChanges();
        }

        public void DeleteBooking(int bookingId)
        {
            var booking = GetBooking(bookingId);

            data
             .Bookings
             .Remove(booking);

            data.SaveChanges();
        }

        private void EnsurePropertyExists(int propertyId)
        {
            var property = data
                .Properties
                .FirstOrDefault(x => x.Id == propertyId);

            if (property == null)
            {
                throw new ArgumentNullException(string.Format(NotExistingPropertyErrorMessage, propertyId));
            }
        }

        private Booking GetBooking(int bookingId)
        {
            var booking = data
                            .Bookings
                            .Find(bookingId);

            if (booking == null)
            {
                throw new ArgumentNullException(string.Format(NotExistingBookingErrorMessage, bookingId));
            }

            return booking;
        }

        private void AssignBookingToClient(Client client, string visitDate, string description, int propertyId)
        {
            var date = ParseDate(visitDate);

            var booking = new Booking
            {
                Client = client,
                ClientId = client.Id,
                Description = description,
                PropertyId = propertyId,
                VisitDate = date
            };

            client.Bookings.Add(booking);
        }

        private DateTime ParseDate(string date)
        {
            DateTime parsedDate;

            DateTime.TryParseExact(
                date, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate);

            return parsedDate;
        }
    }
}
