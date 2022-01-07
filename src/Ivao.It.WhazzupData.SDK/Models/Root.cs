using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class Root
    {
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("servers")]
        public List<Server> Servers { get; set; }

        [JsonPropertyName("voiceServers")]
        public List<VoiceServer> VoiceServers { get; set; }

        [JsonPropertyName("clients")]
        public Clients Clients { get; set; }

        [JsonPropertyName("connections")]
        public Connections Connections { get; set; }
    }
}
