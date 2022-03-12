namespace RealEstateWebApp.ViewModels.Properties
{
    public class ListPropertyViewModel
    {
        public int Id { get; init; }

        public string Description { get; init; }

        public decimal Price { get; init; }

        public string ImageUrl { get; init; }

        public int BuildingYear { get; init; }

        public int Floor { get; init; }

        public string PropertyType { get; init; }
    }
}
