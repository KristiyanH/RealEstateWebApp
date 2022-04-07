namespace RealEstateWebApp.ViewModels.Bookings
{
    public class AllBookingsViewModel
    {
        public int BookingId { get; init; }

        public string VisitDate { get; set; }

        public string Description { get; init; }

        public int PropertyId { get; init; }

        public string ClientFullName { get; init; }

        public string ClientPhoneNumber { get; init; }

        public string ClientEmail { get; init; }
    }
}
