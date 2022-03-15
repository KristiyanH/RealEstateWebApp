using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateWebApp.Data;
using RealEstateWebApp.Models;
using RealEstateWebApp.ViewModels.Home;
using System.Diagnostics;
using System.Linq;

namespace RealEstateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RealEstateDbContext data;

        public HomeController(ILogger<HomeController> logger, RealEstateDbContext _data)
        {
            data = _data;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var propertiesCount = data.Properties.Count();

            var properties = data.Properties.Select(x => new PropertyIndexViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            })
            .ToList();


            return View(new IndexViewModel()
            {
                TotalProperties = propertiesCount,
                Properties = properties
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
