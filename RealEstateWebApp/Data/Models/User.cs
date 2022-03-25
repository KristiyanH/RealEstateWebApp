using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(NameMaxValue)]
        public string FullName { get; set; }
    }
}
