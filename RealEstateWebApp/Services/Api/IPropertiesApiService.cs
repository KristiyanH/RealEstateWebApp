using RealEstateWebApp.Data.Models;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Api
{
    public interface IPropertiesApiService
    {
        public IEnumerable<Property> GetPropertiesList();

        public Property GetPropertyById(int id);
    }
}
