using Microsoft.AspNetCore.Mvc;
using site_clima_api.Models;
using site_clima_api.Services;

namespace site_clima_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly CurrentWeatherService _weatherService;

        public CurrentWeatherController(CurrentWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("city/{cityName}")]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            var weatherData = await _weatherService.GetWeatherByCityName(cityName);

            if (weatherData == null || weatherData.Current == null)
            {
                return NotFound("Não foi possível obter os dados do clima.");
            }

            return Ok(weatherData);
        }

        [HttpGet("city/list/{cityName}")]
        public async Task<IActionResult> GetListWeather(string cityName)
        {
            if (cityName.Length < 3)
            {
                return NotFound("Precisa de no minimo três letras para a consulta.");
            }

            var weatherData = await _weatherService.GetWeatherListByCityName(cityName);

            if (weatherData == null)
            {
                return NotFound("Não foi possível obter a lista de cidades.");
            }

            return Ok(weatherData);
        }


        [HttpGet("city/ip")]
        public IActionResult GetUserIp()
        {
            string? ipUsuario = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (string.IsNullOrEmpty(ipUsuario))
            {
                ipUsuario = HttpContext.Connection.RemoteIpAddress?.ToString();
            }

            if (string.IsNullOrEmpty(ipUsuario))
            {
                return NotFound("Não foi possível obter o IP do usuário.");
            }

            // Retorna o IP diretamente
            return Ok(ipUsuario);
        }

    }
}

