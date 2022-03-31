using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateWebApp.Data.Models;

namespace RealEstateWebApp.Data
{
    public class RealEstateDbContext : IdentityDbContext<User>
    {

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            : base(options)
        {
        }


        public DbSet<Property> Properties { get; init; }

        public DbSet<PropertyType> PropertyTypes { get; init; }

        public DbSet<Address> Addresses { get; init; }

        public DbSet<Task> Tasks { get; init; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Property>()
                .HasOne(p => p.PropertyType)
                .WithMany(pt => pt.Properties)
                .HasForeignKey(p => p.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Address>()
                .HasMany(a => a.Properties)
                .WithOne(p => p.Address)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Task>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
