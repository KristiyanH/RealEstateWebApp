namespace RealEstateWebApp.Data
{
    public class DataConstants
    {
        public const int DescriptionMaxLength = 1000;
        public const int DescriptionMinLength = 10;
        public const int BuildingYearMinValue = 1800;
        public const int BuildingYearMaxValue = 2050;
        public const int PropertyFloorMinValue = 0;
        public const int PropertyFloorMaxValue = 300;
        public const int SquareMetersMinValue = 10;
        public const int SquareMetersMaxValue = 10000;
        public const double PropertyPriceMinValue = 5000;
        public const long PropertyPriceMaxValue = 100000000;

        public const string RequiredAndRangeErrorMessage = "The field is required and should be in range [{1}-{2}].";
        public const string FloorErrorMessage = "Floor is required and should be in range [{1}-{2}].";
        public const string DescriptionErrorMessage = "Description should be between {2} and {1} characters long.";

        public const int LocationNamesMaxLength = 200;

        public const int AddressTextMaxLength = 300;
    }
}
