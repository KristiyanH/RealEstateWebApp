using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Properties;
using System.Collections.Generic;
using System.Linq;

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

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            var properties = data.Properties.Select(x => new ListPropertyViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToList();

            
            return View(properties);
        }

        public IActionResult Remove(int propertyId)
        {
            var property = data.Properties.FirstOrDefault(x => x.Id == propertyId);

            if (property != null)
            {
                data.Properties.Remove(property);
                data.SaveChanges();
                return Redirect("/Properties/All");
            }

            return RedirectToAction("Index", "Home");
        }

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
