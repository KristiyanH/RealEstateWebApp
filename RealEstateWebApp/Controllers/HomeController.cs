﻿using AutoMapper;
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
        private readonly RealEstateDbContext data;
        private readonly IMapper mapper;
        public HomeController(RealEstateDbContext _data,
            IMapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            var propertiesCount = data.Properties.Count();

            var properties = data.Properties.ToList();

            var mappedProperties = mapper.Map<List<PropertyIndexViewModel>>(properties);

            foreach (var prop in mappedProperties)
            {
                prop.Address = data.Addresses.FirstOrDefault(x => x.Id == prop.AddressId);
            }
            return View(new IndexViewModel()
            {
                TotalProperties = propertiesCount,
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
