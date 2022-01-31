using System.ComponentModel.DataAnnotations;

namespace Journey.Web.Models
{
    public class BaseViewModel
    {
        [Required]
        public string SessionId { get; set; }
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int FromId { get; set; }
        [Required]
        public int ToId { get; set; }
    }
}
