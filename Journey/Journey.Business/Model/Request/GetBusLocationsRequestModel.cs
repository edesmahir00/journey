using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Business.Model.Request
{
    public class GetBusLocationsRequestModel
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }


}
