using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class Aircraft
    {
        [JsonPropertyName("icaoCode")]
        public string IcaoCode { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("wakeTurbulence")]
        public string WakeTurbulence { get; set; }

        [JsonPropertyName("isMilitary")]
        public bool? IsMilitary { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }


}
