using Newtonsoft.Json;

namespace Journey.Business.Model.Request
{
    public class GetSessionRequestModel
    {

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }
    }

    public class Connection
    {
    }

    public class Application
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }

   
}
