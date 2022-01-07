using System;
using System.Text.Json.Serialization;

namespace Ivao.It.WhazzupData.SDK.Models
{
    public class FlightPlan
    {
        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("aircraftId")]
        public string AircraftId { get; set; }

        [JsonPropertyName("aircraftNumber")]
        public int AircraftNumber { get; set; }

        [JsonPropertyName("departureId")]
        public string DepartureId { get; set; }

        [JsonPropertyName("arrivalId")]
        public string ArrivalId { get; set; }

        [JsonPropertyName("alternativeId")]
        public string AlternativeId { get; set; }

        [JsonPropertyName("alternative2Id")]
        public string Alternative2Id { get; set; }

        [JsonPropertyName("route")]
        public string Route { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("speed")]
        public string Speed { get; set; }

        [JsonPropertyName("level")]
        public string Level { get; set; }

        [JsonPropertyName("flightRules")]
        public string FlightRules { get; set; }

        [JsonPropertyName("flightType")]
        public string FlightType { get; set; }

        [JsonPropertyName("eet")]
        public int Eet { get; set; }

        [JsonPropertyName("endurance")]
        public int Endurance { get; set; }

        [JsonPropertyName("departureTime")]
        public int DepartureTime { get; set; }

        [JsonPropertyName("actualDepartureTime")]
        public int ActualDepartureTime { get; set; }

        [JsonPropertyName("peopleOnBoard")]
        public int PeopleOnBoard { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("aircraftEquipments")]
        public string AircraftEquipments { get; set; }

        [JsonPropertyName("aircraftTransponderTypes")]
        public string AircraftTransponderTypes { get; set; }

        [JsonPropertyName("aircraft")]
        public Aircraft Aircraft { get; set; }
    }


}
