using System;
using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class LastTrack
    {
        [JsonPropertyName("altitude")]
        public int Altitude { get; set; }

        [JsonPropertyName("altitudeDifference")]
        public int AltitudeDifference { get; set; }

        [JsonPropertyName("arrivalDistance")]
        public double? ArrivalDistance { get; set; }

        [JsonPropertyName("departureDistance")]
        public double? DepartureDistance { get; set; }

        [JsonPropertyName("groundSpeed")]
        public int GroundSpeed { get; set; }

        [JsonPropertyName("heading")]
        public int Heading { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("onGround")]
        public bool OnGround { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("transponder")]
        public int Transponder { get; set; }

        [JsonPropertyName("transponderMode")]
        public string TransponderMode { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }


}
