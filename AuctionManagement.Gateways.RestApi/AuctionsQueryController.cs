using Microsoft.AspNetCore.Mvc;

namespace AuctionManagement.Gateways.RestApi
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionsQueryController : ControllerBase
    {
        public AuctionsQueryController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
