using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.ViewModels.Properties;
using System;
using static RealEstateWebApp.ErrorConstants;

namespace RealEstateWebApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService propertyService;

        public PropertiesController(IPropertyService _propertyService)
            => propertyService = _propertyService;

        [Authorize]
        public IActionResult Add()
            => View(new AddPropertyFormModel
            {
                PropertyTypes = propertyService.GetPropertyTypes()
            });

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPropertyFormModel property)
        {
            if (!propertyService.DoesPropertyTypeExists(property.PropertyTypeId))
            {
                ModelState.AddModelError(nameof(property.PropertyTypeId), string.Format(NotExistingPropertyTypeMessage, property.PropertyTypeId));
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
                return RedirectToAction(nameof(All));
            }
            catch (ArgumentNullException aex)
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
            catch (ArgumentNullException ex)
            {
                ViewData["ErrorTitle"] = ErrorTitle;
                ViewData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }
    }
}
