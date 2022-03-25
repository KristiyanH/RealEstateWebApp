﻿using Microsoft.AspNetCore.Builder;
using RealEstateWebApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RealEstateWebApp.Data.Models;
using System;
using Microsoft.AspNetCore.Identity;
using static RealEstateWebApp.WebConstants;
namespace RealEstateWebApp.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedPropertyTypes(services);
            SeedManager(services);
            

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<RealEstateDbContext>();

            data.Database.Migrate();
        }

        private static void SeedPropertyTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<RealEstateDbContext>();

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

        private static void SeedManager(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            System.Threading.Tasks.Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(ManagerRoleName))
                {
                    return;
                }

                var managerRole = new IdentityRole { Name = ManagerRoleName };
                var employeeRole = new IdentityRole { Name = EmployeeRoleName };
                await roleManager.CreateAsync(managerRole);
                await roleManager.CreateAsync(employeeRole);

                var managerEmail = "kristiyan.a.hristov@gmail.com";
                var managerFullName = "Kristiyan Hristov";
                const string managerPassword = "123456";

                var manager = new User
                {
                    Email = managerEmail,
                    UserName = managerEmail,
                    FullName = managerFullName
                };

                await userManager.CreateAsync(manager, managerPassword);
                await userManager.AddToRoleAsync(manager, managerRole.Name);

                var employeeEmail = "cahristov@gmail.com";
                var employeeFullName = "Pesho Petrov";

                var employee = new User
                {
                    Email = employeeEmail,
                    UserName = employeeEmail,
                    FullName = employeeFullName
                };

                await userManager.CreateAsync(employee, managerPassword);
                await userManager.AddToRoleAsync(employee, employeeRole.Name);

            })
                .GetAwaiter()
                .GetResult();
        }

        
    }
}
