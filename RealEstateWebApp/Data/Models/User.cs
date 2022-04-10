using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants.User;

namespace RealEstateWebApp.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Tasks = new List<Task>();
        }

        [MaxLength(NameMaxValue)]
        public string FullName { get; set; }

        public string ProfilePicutre { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
