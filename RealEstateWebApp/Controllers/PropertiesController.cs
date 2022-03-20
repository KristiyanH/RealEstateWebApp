using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using RealEstateWebApp.Infrastructure;
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

        [Authorize]
        public IActionResult Add()
        {
            if (!isUserAuthorized())
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new AddPropertyFormModel
            {
                PropertyTypes = propertyService.GetPropertyTypes()
            });
            
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPropertyFormModel property)
        {
            if (!isUserAuthorized())
            {
                return RedirectToAction("Index", "Home");
            }

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

        [Authorize]
        public IActionResult Remove(int Id)
        {
            if (!isUserAuthorized())
            {
                return RedirectToAction("Index", "Home");
            }

            if (propertyService.Remove(Id))
            {
                return Redirect("/Properties/All");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var property = propertyService.Details(id);

            if (property == null)
            {
                ModelState.AddModelError(nameof(property.Id), "Property type does not exist.");
            }

            return View(property);
        }

        private bool isUserAuthorized()
        {
            bool isAuthorized = false;

            var isUserEmployee = data
                .Employees
                .Any(e => e.UserId == User.GetId());

            var isUserManager = data
                .Managers
                .Any(m => m.UserId == User.GetId());

            if (isUserManager || isUserEmployee)
            {
                isAuthorized = true;
            }

            return isAuthorized;
        }
    }
}
