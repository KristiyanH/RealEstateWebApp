using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Data
{
    public class Roles
    {
        public static IEnumerable<IdentityRole> TenRoles()
            => Enumerable.Range(0, 10).Select(x => new IdentityRole());

        public static IdentityRole Role()
        {
            return new IdentityRole()
            {
                Id = "c6b71150-24ae-47d8-9a7c-da9fbfbbb386",
                Name = "Manager"
            };
        }
    }
}
