using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateWebApp.Data;
using RealEstateWebApp.Models;
using RealEstateWebApp.ViewModels.Home;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RealEstateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RealEstateDbContext data;
        private readonly IMapper mapper;
        public HomeController(ILogger<HomeController> logger,
            RealEstateDbContext _data,
            IMapper _mapper)
        {
            data = _data;
            _logger = logger;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            var propertiesCount = data.Properties.Count();

            var properties = data.Properties.ToList();

            var mappedProperties = mapper.Map<List<PropertyIndexViewModel>>(properties);

            return View(new IndexViewModel()
            {
                TotalProperties = propertiesCount,
                Properties = mappedProperties
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
            => View();


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        //}
    }
}
