﻿namespace RealEstateWebApp.Data
{
    public class DataConstants
    {
        public const string RequiredAndRangeErrorMessage = "The field is required and should be in range [{1}-{2}].";
        public const string DescriptionErrorMessage = "Description should be between {2} and {1} characters long.";
        public const int AddressTextMaxLength = 300;
        public const int PropertyTypeNameMaxLength = 20;
        public class Property
        {
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 10;
            public const int BuildingYearMinValue = 1800;
            public const int BuildingYearMaxValue = 2050;
            public const int FloorMinValue = 0;
            public const int FloorMaxValue = 300;
            public const int SquareMetersMinValue = 10;
            public const int SquareMetersMaxValue = 10000;
            public const string FloorErrorMessage = "Floor is required and should be in range [{1}-{2}].";
        }

        
        public class User
        {
            public const int NameMinValue = 3;
            public const int NameMaxValue = 70;
            public const int PhoneNumberMinValue = 6;
            public const int PhoneNumberMaxValue = 20;
        }
        
    }
}
