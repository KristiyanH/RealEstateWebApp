using System.Security.Claims;

namespace RealEstateWebApp.Infrastructure
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetId(this ClaimsPrincipal principal)
            => principal.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
