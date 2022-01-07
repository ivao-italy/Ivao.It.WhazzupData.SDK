using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class Clients
    {
        [JsonPropertyName("pilots")]
        public List<Pilot> Pilots { get; set; }

        [JsonPropertyName("atcs")]
        public List<Atc> Atcs { get; set; }

        [JsonPropertyName("followMe")]
        public List<object> FollowMe { get; set; }

        [JsonPropertyName("observers")]
        public List<Observer> Observers { get; set; }
    }


}
