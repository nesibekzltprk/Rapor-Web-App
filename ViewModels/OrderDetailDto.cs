using System.Text.Json.Serialization;

namespace RaporFront.NewFolder
{
    public class OrderDetailDto
    {
        [JsonPropertyName("OrderID")]
        public int OrderID { get; set; }

        [JsonPropertyName("CustomerID")]
        public string CustomerID { get; set; }

        [JsonPropertyName("EmployeeID")]
        public int EmployeeID { get; set; }

        [JsonPropertyName("OrderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("EmployeeLastName")]
        public string EmployeeLastName { get; set; }

        [JsonPropertyName("EmployeeFirstName")]
        public string EmployeeFirstName { get; set; }

        [JsonPropertyName("EmployeeTitle")]
        public string EmployeeTitle { get; set; }

        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("ContactName")]
        public string ContactName { get; set; }

        [JsonPropertyName("ContactTitle")]
        public string ContactTitle { get; set; }

        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        [JsonPropertyName("ProductID")]
        public int ProductID { get; set; }

        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }

        [JsonPropertyName("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("UnitsInStock")]
        public short UnitsInStock { get; set; }
    }
}
