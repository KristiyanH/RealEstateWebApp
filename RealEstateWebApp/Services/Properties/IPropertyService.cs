﻿using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;

namespace RealEstateWebApp.Services.Properties
{
    public interface IPropertyService
    {
        public IEnumerable<PropertyTypeViewModel> GetPropertyTypes();

        public void Add(AddPropertyFormModel property);

        public AllPropertiesQueryModel All([FromQuery] AllPropertiesQueryModel query);

        public void Remove(int Id);

        public DetailsPropertyViewModel Details(int id);

        public bool DoesPropertyTypeExists(int propertyTypeId);

        public IEnumerable<Property> GetPropertiesList();

        public IEnumerable<Address> GetAddressesList();
    }
}
