using Microsoft.AspNetCore.Builder;
using RealEstateWebApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RealEstateWebApp.Data.Models;

namespace RealEstateWebApp.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
           using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<RealEstateDbContext>();

            SeedPropertyTypes(data);

            data.Database.Migrate();

            return app;
        }

        private static void SeedPropertyTypes(RealEstateDbContext data)
        {
            if (data.PropertyTypes.Any())
            {
                return;
            }

            data.PropertyTypes.AddRange(new[]
            {
                new PropertyType{ Name = "Apartment"},
                new PropertyType{ Name = "Villa"},
                new PropertyType{ Name = "House"},
                new PropertyType{ Name = "Mansion"},
                new PropertyType{ Name = "Residence"},
            });

            data.SaveChanges();
        }
    }
}
