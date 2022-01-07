using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class Connections
    {
        [JsonPropertyName("atc")]
        public int Atc { get; set; }

        [JsonPropertyName("followMe")]
        public int FollowMe { get; set; }

        [JsonPropertyName("observers")]
        public int Observers { get; set; }

        [JsonPropertyName("pilots")]
        public int Pilots { get; set; }

        [JsonPropertyName("supervisors")]
        public int Supervisors { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("worldTours")]
        public int WorldTours { get; set; }
    }


}
