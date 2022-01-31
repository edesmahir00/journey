using Newtonsoft.Json;

namespace Journey.Business.Model.Response
{
    public class GetSessionResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public object Controller { get; set; }

        [JsonProperty("client-request-id")]
        public object ClientRequestId { get; set; }

    }

    public class Data
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        [JsonProperty("affiliate")]
        public object Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }

        [JsonProperty("device")]
        public object Device { get; set; }
    }
}
