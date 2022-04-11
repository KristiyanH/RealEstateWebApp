using AutoMapper;
using Moq;
using RealEstateWebApp.Infrastructure;

namespace RealEstateWebApp.Tests.Mocks
{
    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });

                return new Mapper(mapperConfiguration);
            }
        }
    }
}
