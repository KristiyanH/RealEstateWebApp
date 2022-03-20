using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateWebApp.Data.DataConstants;
namespace RealEstateWebApp.Data.Models
{
    public class PropertyType
    {
        public PropertyType()
            => Properties = new List<Property>();

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(PropertyTypeNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; init; }
    }
}
