using RealEstateWebApp.Data.Models;

namespace RealEstateWebApp.Tests.Data
{
    public class Bookings
    {
        public static Client Client()
        {
            return new Client
            {
                Email = "kristiyan.a.hristov@gmail.com",
                FullName = "Kristiyan Hristov",
                Id = 1,
                PhoneNumber = "0876065511",
                UserId = "3f165359-3f79-4fa0-aefb-c030ac5ebd87"
            };
        }
    }
}
