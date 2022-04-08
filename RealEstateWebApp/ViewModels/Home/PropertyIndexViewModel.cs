using RealEstateWebApp.Data.Models;

namespace RealEstateWebApp.ViewModels.Home
{
    public class PropertyIndexViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
