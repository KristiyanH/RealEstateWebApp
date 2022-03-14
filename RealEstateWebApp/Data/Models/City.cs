using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants;

namespace RealEstateWebApp.Data.Models
{
    public class City
    {
        public City()
        {
            Properties = new List<Property>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LocationNamesMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}
