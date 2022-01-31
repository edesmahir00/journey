namespace Journey.Web.Models
{
    public class AvaiableJourneysViewModel : BaseViewModel
    {
        public string FromLocationText { get; set; }
        public string ToLocationText { get; set; }
        public List<AvaiableJourneyViewModel> AvaiableJourneysList { get; set; }
    }

    public class AvaiableJourneyViewModel
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public Decimal Price { get; set; }

    }


}
