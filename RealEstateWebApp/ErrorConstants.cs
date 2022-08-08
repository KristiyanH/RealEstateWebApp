namespace RealEstateWebApp
{
    public class ErrorConstants
    {
        public const string NotExistingPropertyErrorMessage = "Property with id:{0} does not exist";
        public const string NotExistingBookingErrorMessage = "Booking with id: {0} does not exist.";
        public const string NotExistingClientErrorMessage = "Client with id: {0} does not exist.";
        public const string NotExistingTaskErrorMessage = "Task with id: {0} not found!";
        public const string NotExistingUserErrorMessage = "User with id: {0} not found!";

        public const string RequiredAndRangeErrorMessage = "The field is required and should be in range [{1}-{2}].";
        public const string DescriptionErrorMessage = "Description should be between {2} and {1} characters long.";
        public const string ErrorTitle = "Could not execute action, look the message below for more info.";
    }
}
