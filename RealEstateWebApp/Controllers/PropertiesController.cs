using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.ViewModels.Properties;
using System.Linq;
using static RealEstateWebApp.ErrorConstants;
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

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddPropertyFormModel
            {
                PropertyTypes = propertyService.GetPropertyTypes()
            });

        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPropertyFormModel property)
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

        [Authorize(Roles = "Manager,Employee")]
        public IActionResult Remove(int Id)
        {
            try
            {
                propertyService.Remove(Id);
                return Redirect("/Properties/All");
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = aex.Message;

                return View("Error");
            }

        }

        public IActionResult Details(int id)
        {
            try
            {
                var property = propertyService.Details(id);
                return View(property);
            }
            catch (ArgumentException aex)
            {
                ViewData["ErrorTitle"] = "Could not execute action, look the message below for more info";
                ViewData["ErrorMessage"] = aex.Message;
                return View("Error");
            }
        }
    }
}
