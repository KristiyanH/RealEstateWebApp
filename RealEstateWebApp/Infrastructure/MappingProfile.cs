using AutoMapper;
using RealEstateWebApp.Data.Models;
using RealEstateWebApp.ViewModels.Bookings;
using RealEstateWebApp.ViewModels.Home;
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

            CreateMap<Property, PropertyIndexViewModel>();

            CreateMap<Booking, AllBookingsViewModel>()
                .ForMember(x => x.BookingId, cfg => cfg.MapFrom(x => x.Id));
        }
    }
}
