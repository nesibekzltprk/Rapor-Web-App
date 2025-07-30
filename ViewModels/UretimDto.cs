using System.Text.Json.Serialization;

namespace RaporFront.ViewModels
{
    public class UretimDto
    {
        [JsonPropertyName("ProductID")]
        public int ProductID { get; set; }

        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }

        [JsonPropertyName("CategoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("UnitsInStock")]
        public short UnitsInStock { get; set; }
    }
}
