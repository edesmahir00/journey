using Microsoft.AspNetCore.Mvc.Rendering;

namespace Journey.Web.Models
{
    public class DashboardViewModel : BaseViewModel
    { 
        public List<SelectListItem> FromLocations { get; set; }
        public List<SelectListItem> ToLocations { get; set; }
    }
}
