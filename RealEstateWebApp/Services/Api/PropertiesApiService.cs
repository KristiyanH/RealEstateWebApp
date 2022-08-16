using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Services.Api
{
    public class PropertiesApiService : IPropertiesApiService
    {
        private readonly RealEstateDbContext data;

        public PropertiesApiService(RealEstateDbContext _data)
           => data = _data;

        public IEnumerable<Property> GetPropertiesList()
        {
            return data.Properties.ToList();
        }

        public Property GetPropertyById(int id)
        {
            return data.Properties.Find(id);
        }
    }
}
