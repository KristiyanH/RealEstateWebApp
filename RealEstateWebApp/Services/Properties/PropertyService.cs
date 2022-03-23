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

        public PropertyService(RealEstateDbContext _data)
            => data = _data;

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

            var newProperty = new Property()
            {
                BuildingYear = property.BuildingYear,
                Description = property.Description,
                Floor = property.Floor,
                ImageUrl = property.ImageUrl,
                Price = property.Price,
                PropertyTypeId = property.PropertyTypeId,
                SquareMeters = property.SquareMeters,
                PropertyType = data.PropertyTypes.FirstOrDefault(x => x.Id == property.PropertyTypeId),
                AddressId = address.Id
            };

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

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                propertiesQuery = propertiesQuery.Where(x =>
                x.PropertyType.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                x.BuildingYear.ToString().ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var totalProperties = propertiesQuery.Count();

            var properties = propertiesQuery
                .Skip((query.CurrentPage - 1) * AllPropertiesQueryModel.PropertiesPerPage)
                .Take(AllPropertiesQueryModel.PropertiesPerPage)
                .Select(x => new ListPropertyViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    PropertyType = data.PropertyTypes.FirstOrDefault(pt => pt.Id == x.PropertyTypeId).Name
                })
              .ToList();

            var propertyTypes = data
                .PropertyTypes
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            query.TotalProperties = totalProperties;
            query.Properties = properties;
            query.Types = propertyTypes;

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

            var address = data.Addresses.FirstOrDefault(x => x.Id == property.AddressId);
            var propertyType = data.PropertyTypes.FirstOrDefault(x => x.Id == property.PropertyTypeId);

            var detailsModel = new DetailsPropertyViewModel()
            {
                Id = property.Id,
                Address = address.AddressText,
                BuildingYear = property.BuildingYear,
                Description = property.Description,
                Floor = property.Floor,
                ImageUrl = property.ImageUrl,
                Price = property.Price,
                PropertyType = propertyType.Name,
                SquareMeters = property.SquareMeters
            };

            return detailsModel;
        }
    }
}
