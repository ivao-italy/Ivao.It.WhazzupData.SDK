using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class VoiceServer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("countryId")]
        public string CountryId { get; set; }

        [JsonPropertyName("currentConnections")]
        public int CurrentConnections { get; set; }

        [JsonPropertyName("maximumConnections")]
        public int MaximumConnections { get; set; }
    }


}
