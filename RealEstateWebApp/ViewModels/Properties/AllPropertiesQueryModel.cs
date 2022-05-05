using RealEstateWebApp.ViewModels.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateWebApp.ViewModels.Properties
{
    public class AllPropertiesQueryModel
    {
        public const int PropertiesPerPage = 3;

        [Display(Name = "Search Residence by Type")]
        public string Type { get; init; }

        [Display(Name = "Search By Address")]
        public string Address { get; init; }

        public int CurrentPage { get; init; } = 1;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public int TotalProperties { get; set; }

        public IEnumerable<string> Types { get; set; }

        public IEnumerable<string> Addresses { get; set; }

        public IEnumerable<ListPropertyViewModel> Properties { get; set; }
    }
}
