using RealEstateWebApp.Data.Models;

namespace RealEstateWebApp.ViewModels.Properties
{
    public class PropertyViewModel
    {
        public int Id { get; init; }

        public string Description { get; init; }

        public decimal Price { get; init; }

        public string ImageUrl { get; init; }

        public int BuildingYear { get; init; }

        public int Floor { get; init; }

        public string PropertyType { get; set; }

        public string Address { get; set; }

        public decimal SquareMeters { get; init; }
    }
}
