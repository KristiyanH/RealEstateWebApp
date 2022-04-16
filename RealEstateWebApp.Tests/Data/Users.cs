using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Data
{
    public class Users
    {
        public static IEnumerable<User> TenUsers()
            => Enumerable.Range(0, 10).Select(x => new User());
    }
}
