using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Data
{
    public class PropertyTypes
    {
        public static IEnumerable<PropertyType> TenPropertyTypes()
           => Enumerable.Range(0, 10).Select(x => new PropertyType());
    }
}
