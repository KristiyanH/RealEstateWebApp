using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateWebApp.Data.Models;

namespace RealEstateWebApp.Data
{
    public class RealEstateDbContext : IdentityDbContext
    {

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            : base(options)
        {
        }


        public DbSet<Property> Properties { get; init; }

        public DbSet<PropertyType> PropertyTypes { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Property>()
                .HasOne(x => x.PropertyType)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
