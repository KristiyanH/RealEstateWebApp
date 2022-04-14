using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Bookings
{
    public class EditBookingFormModel
    {
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Display(Name = "Visit Date")]
        public string VisitDate { get; set; }

        public string Description { get; set; }
    }
}
