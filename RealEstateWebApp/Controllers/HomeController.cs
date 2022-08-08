using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Properties;
using RealEstateWebApp.ViewModels.Home;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService propertyService;
        private readonly IMapper mapper;

        public HomeController(IMapper _mapper,
            IPropertyService _propertyService)
        {
            mapper = _mapper;
            propertyService = _propertyService;
        }

        public IActionResult Index()
        {
            var properties = propertyService.GetPropertiesList();
            var addresses = propertyService.GetAddressesList();

            var mappedProperties = mapper.Map<List<PropertyIndexViewModel>>(properties);

            foreach (var property in mappedProperties)
            {
                property.Address = addresses.FirstOrDefault(x => x.Id == property.AddressId);
            }

            return View(new IndexViewModel()
            {
                TotalProperties = properties.Count(),
                Properties = mappedProperties
            });
        }

        public IActionResult About()
           => View();

        public IActionResult Error()
            => View();

        public IActionResult Contact()
            => View();
    }
}
