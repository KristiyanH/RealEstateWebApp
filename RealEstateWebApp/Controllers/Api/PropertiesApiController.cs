using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Services.Api;
using System.Collections;

namespace RealEstateWebApp.Controllers.Api
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesApiController : ControllerBase
    {
        private readonly IPropertiesApiService propertiesApiService;

        public PropertiesApiController(IPropertiesApiService _propertiesApiService)
           => propertiesApiService = _propertiesApiService;

        [HttpGet]
        public IEnumerable GetProperties()
        {
            return propertiesApiService.GetPropertiesList();
        }

        [HttpGet]
        [Route("{id}")]
        public object GetPropertyDetails(int id)
        {
            return propertiesApiService.GetPropertyById(id);
        }
    }
}
