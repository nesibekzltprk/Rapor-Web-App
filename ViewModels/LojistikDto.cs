using System.Text.Json.Serialization;

namespace RaporFront.ViewModels
{
    public class LojistikDto
    {
        [JsonPropertyName("OrderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("ShipName")]
        public string ShipName { get; set; }

        [JsonPropertyName("ShipAddress")]
        public string ShipAddress { get; set; }

        [JsonPropertyName("ShipCity")]
        public string ShipCity { get; set; }

        [JsonPropertyName("ShipCountry")]
        public string ShipCountry { get; set; }

        [JsonPropertyName("ShipperName")]
        public string ShipperName { get; set; }
    }
}
