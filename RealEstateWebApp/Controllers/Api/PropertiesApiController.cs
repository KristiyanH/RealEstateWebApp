using Microsoft.AspNetCore.Mvc;
using RealEstateWebApp.Data;
using System.Collections;
using System.Linq;

namespace RealEstateWebApp.Controllers.Api
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesApiController : ControllerBase
    {
        private readonly RealEstateDbContext data;

        public PropertiesApiController(RealEstateDbContext _data)
           => data = _data;

        [HttpGet]
        public IEnumerable GetProperties()
        {
            return data.Properties.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public object GetPropertyDetails(int id)
        {
            return data.Properties.Find(id);
        }
    }
}
