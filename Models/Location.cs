using System.Text.Json.Serialization;

namespace site_clima_api.Models
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("region")]
        public string? Region { get; set; }
        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}
