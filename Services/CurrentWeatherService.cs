using site_clima_api.Models;
using System.Text.Json;

namespace site_clima_api.Services
{
    public class CurrentWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public CurrentWeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["API_KEY"];
        }

        public async Task<CurrentWeather> GetWeatherByCityName(string cityName)
        {
            try
            {
                string url = $"https://api.weatherapi.com/v1/forecast.json?key={_apiKey}&q={cityName}&lang=pt";
                var response = await _httpClient.GetStringAsync(url);
                var weatherData = JsonSerializer.Deserialize<CurrentWeather>(response);

                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar clima: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Location>> GetWeatherListByCityName(string cityName)
        {
            try
            {
                string url = $"https://api.weatherapi.com/v1/search.json?key={_apiKey}&q={cityName}&lang=pt";
                var response = await _httpClient.GetStringAsync(url);
                var weatherData = JsonSerializer.Deserialize<List<Location>>(response);

                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar clima: {ex.Message}");
                return null;
            }
        }
    }
}