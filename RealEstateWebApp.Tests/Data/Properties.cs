using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Data
{
    public class Properties
    {
        public static IEnumerable<Property> TenProperties()
            => Enumerable.Range(0, 10).Select(x => new Property());
    }
}
