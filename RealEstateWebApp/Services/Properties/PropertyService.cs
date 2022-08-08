using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Services.Properties
{
    public class PropertyService : IPropertyService
    {
        private readonly RealEstateDbContext data;
        private readonly IMapper mapper;

        public PropertyService(RealEstateDbContext _data,
            IMapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        public IEnumerable<PropertyTypeViewModel> GetPropertyTypes()
            => data
            .PropertyTypes
            .ProjectTo<PropertyTypeViewModel>(mapper.ConfigurationProvider);

        public void Add(AddPropertyFormModel property)
        {
            var address = data.Addresses.FirstOrDefault(x => x.AddressText == property.AddressText);

            if (address == null)
            {
                data.Addresses.Add(new Address
                {
                    AddressText = property.AddressText
                });
            }

            var newProperty = mapper.Map<Property>(property);
            newProperty.AddressId = address.Id;
            data.Properties.Add(newProperty);

            address.Properties.Add(newProperty);

            data.SaveChanges();
        }

        public AllPropertiesQueryModel All(AllPropertiesQueryModel query)
        {
            var propertiesQuery = GetPropertiesQuery(query);

            var properties = propertiesQuery
                .Skip((query.CurrentPage - 1) * AllPropertiesQueryModel.PropertiesPerPage)
                .Take(AllPropertiesQueryModel.PropertiesPerPage)
                .ProjectTo<PropertyViewModel>(mapper.ConfigurationProvider);

            var propertyTypes = data
                .PropertyTypes
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var propertyAddresses = data
                .Addresses
                .Select(x => x.AddressText)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            query.TotalProperties = propertiesQuery.Count();
            query.Properties = properties;
            query.Types = propertyTypes;
            query.Addresses = propertyAddresses;
            return query;
        }

        public void Remove(int Id)
        {
            var property = GetProperty(Id);

            data.Properties.Remove(property);
            data.SaveChanges();
        }

        public DetailsPropertyViewModel Details(int id)
        {
            var property = GetProperty(id);

            var propertyDetailsModel = mapper.Map<DetailsPropertyViewModel>(property);

            return propertyDetailsModel;
        }

        public IEnumerable<Property> GetPropertiesList()
        {
            return data
                .Properties
                .ToList();
        }

        public bool DoesPropertyTypeExists(int propertyTypeId)
        {
            return data.PropertyTypes.Any(x => x.Id == propertyTypeId);
        }

        private Property GetProperty(int propertyId)
        {
            var property = data
                .Properties
                .FirstOrDefault(x => x.Id == propertyId);

            if (property == null)
            {
                throw new ArgumentNullException(string.Format(NotExistingPropertyErrorMessage, propertyId));
            }

            return property;
        }

        public IEnumerable<Address> GetAddressesList()
        {
            return data
                .Addresses
                .ToList();
        }

        private IQueryable<Property> GetPropertiesQuery(AllPropertiesQueryModel query)
        {
            var propertiesQuery = data.Properties.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Type))
            {
                propertiesQuery = propertiesQuery.Where(x => x.PropertyType.Name == query.Type);
            }

            if (!string.IsNullOrWhiteSpace(query.Address))
            {
                propertiesQuery = propertiesQuery.Where(x => x.Address.AddressText == query.Address);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                propertiesQuery = propertiesQuery.Where(x =>
                x.PropertyType.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                x.Address.AddressText.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            return propertiesQuery;
        }
    }
}
