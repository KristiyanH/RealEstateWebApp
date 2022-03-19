namespace RealEstateWebApp.ViewModels.Properties
{
    public class DetailsPropertyViewModel
    {
        public int Id { get; init; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int BuildingYear { get; set; }

        public int Floor { get; set; }

        public decimal SquareMeters { get; set; }

        public decimal Price { get; set; }

        public decimal PricePerSquareMeter
            => Price / SquareMeters;

        public string PropertyType { get; set; }

        public string Address { get; set; }
    }
}
