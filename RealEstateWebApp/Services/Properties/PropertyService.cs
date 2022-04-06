using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

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
            .Select(t => new PropertyTypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

        public void Add(AddPropertyFormModel property)
        {
            var address = data.Addresses.FirstOrDefault(x => x.AddressText == property.AddressText);

            if (address == null)
            {
                address = new Address()
                {
                    AddressText = property.AddressText
                };

                data.Addresses.Add(address);
            }

            var newProperty = mapper.Map<Property>(property);
            newProperty.PropertyType = data.PropertyTypes.FirstOrDefault(x => x.Id == property.PropertyTypeId);
            newProperty.PropertyTypeId = data.PropertyTypes.FirstOrDefault(x => x.Id == property.PropertyTypeId).Id;
            newProperty.AddressId = address.Id;

            data.Properties.Add(newProperty);
            address.Properties.Add(newProperty);

            data.SaveChanges();
        }

        public AllPropertiesQueryModel All(AllPropertiesQueryModel query)
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
                x.Address.ToString().ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var totalProperties = propertiesQuery.Count();

            var properties = propertiesQuery
                .Skip((query.CurrentPage - 1) * AllPropertiesQueryModel.PropertiesPerPage)
                .Take(AllPropertiesQueryModel.PropertiesPerPage)
                .ProjectTo<ListPropertyViewModel>(mapper.ConfigurationProvider);

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

            query.TotalProperties = totalProperties;
            query.Properties = properties;
            query.Types = propertyTypes;
            query.Addresses = propertyAddresses;
            return query;
        }

        public bool Remove(int Id)
        {
            bool isRemoved = false;

            var property = data.Properties.FirstOrDefault(x => x.Id == Id);

            if (property != null)
            {
                data.Properties.Remove(property);
                data.SaveChanges();
                isRemoved = true;
            }

            return isRemoved;
        }

        public DetailsPropertyViewModel Details(int id)
        {
            var property = data.Properties.FirstOrDefault(x => x.Id == id);

            if (property == null)
            {
                throw new ArgumentException($"Property with id:{id} does not exist");
            }

            var address = data.Addresses.FirstOrDefault(x => x.Id == property.AddressId);
            var propertyType = data.PropertyTypes.FirstOrDefault(x => x.Id == property.PropertyTypeId);

            var detailsModel = mapper.Map<DetailsPropertyViewModel>(property);
            detailsModel.Address = address.AddressText;
            detailsModel.PropertyType = propertyType.Name;

            return detailsModel;
        }
    }
}
