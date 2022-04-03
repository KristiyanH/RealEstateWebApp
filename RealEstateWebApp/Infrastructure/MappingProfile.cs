using AutoMapper;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Properties;

namespace RealEstateWebApp.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPropertyFormModel, Property>();
            CreateMap<Property, DetailsPropertyViewModel>();
            CreateMap<Property, ListPropertyViewModel>();
        }
    }
}
