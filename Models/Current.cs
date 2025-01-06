using System.Text.Json.Serialization;

namespace site_clima_api.Models
{
    public class Current
    {
        [JsonPropertyName("temp_c")]
        public double Temperature { get; set; }
        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }
        [JsonPropertyName("wind_kph")]
        public double Wind { get; set; }
        [JsonPropertyName("pressure_mb")]
        public double Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("dewpoint_c")]
        public double DewPoint { get; set; }
        [JsonPropertyName("vis_km")]
        public double Visibility { get; set; }
        [JsonPropertyName("feelslike_c")]
        public double SensacaoTermica { get; set; }

    }

    public class Condition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
