using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Data
{
    public class Addresses
    {
        public static IEnumerable<Address> TenAddresses()
           => Enumerable.Range(0, 10).Select(x => new Address()
           {
               AddressText = "Altrincham Road"
           });
    }
}
