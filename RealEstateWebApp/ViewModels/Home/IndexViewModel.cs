using System.Collections.Generic;

namespace RealEstateWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public int TotalProperties { get; init; }

        public List<PropertyIndexViewModel> Properties { get; set; }
    }
}
