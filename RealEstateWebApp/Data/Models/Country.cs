using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants;

namespace RealEstateWebApp.Data.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LocationNamesMaxLength)]
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
