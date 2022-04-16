using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RealEstateWebApp.Data;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using static RealEstateWebApp.WebConstants;
namespace RealEstateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly RealEstateDbContext data;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public HomeController(RealEstateDbContext _data,
            IMapper _mapper,
            IMemoryCache _cache)
        {
            data = _data;
            mapper = _mapper;
            cache = _cache;
        }

        public IActionResult Index()
        {
            var properties = data.Properties.ToList();

            var addresses = data.Addresses.ToList();

            //var properties = cache.Get<List<Property>>(propertiesCacheKey);
            
            ////if (properties == null)
            ////{
            ////    properties = data.Properties.ToList();

            ////    var cacheOptions = new MemoryCacheEntryOptions()
            ////        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

            ////    cache.Set(propertiesCacheKey, properties);
            ////}

            ////var addresses = cache.Get<List<Address>>(addressesCacheKey);

            ////if (addresses == null)
            ////{
            ////    addresses = data.Addresses.ToList();

            ////    var cacheOptions = new MemoryCacheEntryOptions()
            ////        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

            ////    cache.Set(addressesCacheKey, addresses);
            ////}

            var mappedProperties = mapper.Map<List<PropertyIndexViewModel>>(properties);

            foreach (var prop in mappedProperties)
            {
                prop.Address = addresses.FirstOrDefault(x => x.Id == prop.AddressId);
            }

            return View(new IndexViewModel()
            {
                TotalProperties = properties.Count,
                Properties = mappedProperties
            });
        }

        public IActionResult Privacy()
            => View();

        public IActionResult About()
           => View();

        public IActionResult Error()
            => View();

        public IActionResult Contact()
            => View();
    }
}
