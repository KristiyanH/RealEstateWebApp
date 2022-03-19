using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Properties
{
    public interface IPropertyService
    {
        public IEnumerable<PropertyTypeViewModel> GetPropertyTypes();

        public void Add(AddPropertyViewModel property);

        public AllPropertiesQueryModel All([FromQuery] AllPropertiesQueryModel query);

        public bool Remove(int Id);
    }
}
