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

            CreateMap<Property, DetailsPropertyViewModel>()
                .ForMember(x => x.Address, cfg => cfg.MapFrom(x => x.Address.AddressText))
                .ForMember(x => x.PropertyType, cfg => cfg.MapFrom(x => x.PropertyType.Name));

            CreateMap<Property, PropertyViewModel>()
                .ForMember(x => x.Address, cfg => cfg.MapFrom(x => x.Address.AddressText))
                .ForMember(x => x.PropertyType, cfg => cfg.MapFrom(x => x.PropertyType.Name));

            CreateMap<Property, PropertyIndexViewModel>();

            CreateMap<PropertyType, PropertyTypeViewModel>();

            CreateMap<Booking, AllBookingsViewModel>()
                .ForMember(x => x.BookingId, cfg => cfg.MapFrom(x => x.Id));

            CreateMap<Booking, EditBookingFormModel>()
                .ForMember(x => x.BookingId, cfg => cfg.MapFrom(x => x.Id))
                .ForMember(x => x.VisitDate, cfg => cfg.MapFrom(x => x.VisitDate.ToString("dd.MM.yyyy HH:mm")));
        }
    }
}
