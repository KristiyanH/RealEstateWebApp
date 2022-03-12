using RealEstateWebApp.ViewModels.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Properties
{
    public class AllPropertiesQueryModel
    {
        [Display(Name = "Search Residence by Type")]
        public string Type { get; init; }

        public IEnumerable<string> Types { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public PropertySorting Sorting { get; init; }

        public IEnumerable<ListPropertyViewModel> Properties { get; init; }
    }
}
