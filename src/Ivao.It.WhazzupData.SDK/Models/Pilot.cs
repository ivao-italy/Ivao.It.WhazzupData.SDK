using System;
using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class Pilot
    {
        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }

        [JsonPropertyName("serverId")]
        public string ServerId { get; set; }

        [JsonPropertyName("softwareTypeId")]
        public string SoftwareTypeId { get; set; }

        [JsonPropertyName("softwareVersion")]
        public string SoftwareVersion { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("flightPlan")]
        public FlightPlan FlightPlan { get; set; }

        [JsonPropertyName("pilotSession")]
        public PilotSession PilotSession { get; set; }

        [JsonPropertyName("lastTrack")]
        public LastTrack LastTrack { get; set; }
    }


}
