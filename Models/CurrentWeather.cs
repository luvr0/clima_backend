using System.Text.Json.Serialization;

namespace site_clima_api.Models
{
    public class CurrentWeather
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }
        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }

}
