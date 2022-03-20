using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Properties
{
    public interface IPropertyService
    {
        public IEnumerable<PropertyTypeViewModel> GetPropertyTypes();

        public void Add(AddPropertyFormModel property);

        public AllPropertiesQueryModel All([FromQuery] AllPropertiesQueryModel query);

        public bool Remove(int Id);

        public DetailsPropertyViewModel Details(int id);
    }
}
