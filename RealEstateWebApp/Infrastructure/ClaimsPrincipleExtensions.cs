using System.Security.Claims;
using static RealEstateWebApp.WebConstants;

namespace RealEstateWebApp.Infrastructure
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetId(this ClaimsPrincipal principal)
            => principal.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsManager(this ClaimsPrincipal user)
            => user.IsInRole(ManagerRoleName);

        public static bool IsEmployee(this ClaimsPrincipal user)
            => user.IsInRole(EmployeeRoleName);
    }
}
