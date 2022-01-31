using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Business.Model.Request
{
    public class GetBusjourneysRequestModel
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
    public class Data
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public string DepartureDate { get; set; }
    }





}
