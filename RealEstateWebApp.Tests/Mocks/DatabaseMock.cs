using Microsoft.EntityFrameworkCore;
using RealEstateWebApp.Data;
using System;

namespace RealEstateWebApp.Tests.Mocks
{
    public class DatabaseMock
    {
        public static RealEstateDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<RealEstateDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new RealEstateDbContext(dbContextOptions);
            }
        }
    }
}
