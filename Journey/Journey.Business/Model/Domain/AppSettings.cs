namespace Journey.Business.Model.Domain
{
    public class AppSettings
    {
        public OBiletApiSettings OBiletApiSettings { get; set; }
        public int JourneyCookieDurationInMinutes { get; set; }
    }

    public class OBiletApiSettings
    {
        public string BaseUrl { get; set; }
        public string Authorization { get; set; }
    }

}
