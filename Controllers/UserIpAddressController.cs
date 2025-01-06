using Microsoft.AspNetCore.Mvc;
using site_clima_api.Services;

namespace site_clima_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserIpAddressController : ControllerBase
    {
        private readonly UserIpAddressService _userIpAddressService;

        public UserIpAddressController(UserIpAddressService userIpAddressService)
        {
            _userIpAddressService = userIpAddressService;
        }

        [HttpGet("ip")]
        public async Task<IActionResult> GetUserIpAddress()
        {
            var userIpData = await _userIpAddressService.GetIpAddress();

            if (userIpData == null)
            {
                return NotFound("Não foi possível obter o IP do usuário.");
            }

            return Ok(userIpData);
        }
    }
}
