using System.Net.Http;
using System.Threading.Tasks;

namespace site_clima_api.Services
{
    public class UserIpAddressService
    {
        private readonly HttpClient _httpClient;

        public UserIpAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetIpAddress()
        {
            try
            {
                string url = "https://meuip.com/api/meuip.php";

                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                var response = await _httpClient.GetStringAsync(url);

                Console.WriteLine($"Resposta da API: {response}");

                return response.Trim();
            }
            catch (Exception ex)
            {
                // Log de erro
                Console.WriteLine($"Erro ao consultar o IP: {ex.Message}");
                return null;
            }
        }
    }
}
