﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Business.Model.Response
{
    public class GetBusLocationsResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }

        [JsonProperty("client-request-id")]
        public object ClientRequestId { get; set; }
    }

    public class GeoLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("zoom")]
        public int Zoom { get; set; }
    }

    public class Datum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent-id")]
        public int ParentId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty("zoom")]
        public int Zoom { get; set; }

        [JsonProperty("tz-code")]
        public string TzCode { get; set; }

        [JsonProperty("weather-code")]
        public object WeatherCode { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("reference-code")]
        public object ReferenceCode { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }



}
