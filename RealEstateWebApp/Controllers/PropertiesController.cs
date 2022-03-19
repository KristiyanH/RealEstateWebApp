using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.ViewModels.Properties;
using System.Linq;
namespace RealEstateWebApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly RealEstateDbContext data;
        private readonly IPropertyService propertyService;

        public PropertiesController(RealEstateDbContext _data, IPropertyService _propertyService)
        {
            data = _data;
            propertyService = _propertyService;
        }

        public IActionResult Add() => View(new AddPropertyViewModel
        {
            PropertyTypes = propertyService.GetPropertyTypes()
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
                property.PropertyTypes = propertyService.GetPropertyTypes();

                return View(property);
            }

            propertyService.Add(property);

            return RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery] AllPropertiesQueryModel query)
        {
            var resultQuery = propertyService.All(query);

            return View(resultQuery);
        }

        public IActionResult Remove(int Id)
        {
            if (propertyService.Remove(Id))
            {
                return Redirect("/Properties/All");
            }

            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Details(int propertyId)
        //{

        //}
    }
}
