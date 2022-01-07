using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class AtcSession
    {
        [JsonPropertyName("frequency")]
        public double Frequency { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }
    }


}
