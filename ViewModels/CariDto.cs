using System.Text.Json.Serialization;

namespace RaporFront.ViewModels
{
    public class CariDto
    {
        [JsonPropertyName("CustomerID")]
        public string CustomerID { get; set; }

        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("ContactName")]
        public string ContactName { get; set; }

        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
    }
}
