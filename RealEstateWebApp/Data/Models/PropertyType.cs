using System.Collections.Generic;

namespace RealEstateWebApp.Data.Models
{
    public class PropertyType
    {
        public PropertyType()
            => Properties = new List<Property>();

        public int Id { get; init; }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; init; }
    }
}
