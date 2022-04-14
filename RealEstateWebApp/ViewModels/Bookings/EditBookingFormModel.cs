namespace RealEstateWebApp.ViewModels.Bookings
{
    public class EditBookingFormModel
    {
        public int BookingId { get; set; }

        public string VisitDate { get; set; }

        public string Description { get; set; }

        public string ClientFullName { get; set; }

        public string ClientPhone { get; set; }

        public string ClientEmail { get; set; }
    }
}
