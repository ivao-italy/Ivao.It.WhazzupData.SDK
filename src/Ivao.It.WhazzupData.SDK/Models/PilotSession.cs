using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class PilotSession
    {
        [JsonPropertyName("simulatorId")]
        public string SimulatorId { get; set; }
    }


}
