using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RealEstateWebApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly RealEstateDbContext data;

        public PropertiesController(RealEstateDbContext _data)
            => data = _data;


        public IActionResult Add() => View(new AddPropertyViewModel
        {
            PropertyTypes = GetPropertyTypes()
        });


        [HttpPost]
        public IActionResult Add(AddPropertyViewModel property)
        {
            if (!data.PropertyTypes.Any(x => x.Id == property.PropertyTypeId))
            {
                ModelState.AddModelError(nameof(property.PropertyTypeId), "Property type does not exist.");
            }

            if (!ModelState.IsValid)
            {
                property.PropertyTypes = GetPropertyTypes();

                return View(property);
            }

            data.Properties.Add(new Property()
            {
                BuildingYear = property.BuildingYear,
                Description = property.Description,
                Floor = property.Floor,
                ImageUrl = property.ImageUrl,
                Price = property.Price,
                PropertyTypeId = property.PropertyTypeId,
                SquareMeters = property.SquareMeters,
                PropertyType = data.PropertyTypes.FirstOrDefault(x => x.Id == property.PropertyTypeId)
            });

            data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery]AllPropertiesQueryModel query)
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

            var totalProperties = data.Properties.Count();

            var properties = propertiesQuery
                .Skip((query.CurrentPage - 1) * AllPropertiesQueryModel.PropertiesPerPage)
                .Take(AllPropertiesQueryModel.PropertiesPerPage)
                .Select(x => new ListPropertyViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                BuildingYear = x.BuildingYear,
                Floor = x.Floor,
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

            return View(query);
        }

        public IActionResult Remove(int Id)
        {
            var property = data.Properties.FirstOrDefault(x => x.Id == Id);

            if (property != null)
            {
                data.Properties.Remove(property);
                data.SaveChanges();
                return Redirect("/Properties/All");
            }

            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Details(int propertyId)
        //{

        //}
        private IEnumerable<PropertyTypeViewModel> GetPropertyTypes()
            => data
            .PropertyTypes
            .Select(t => new PropertyTypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

    }
}
