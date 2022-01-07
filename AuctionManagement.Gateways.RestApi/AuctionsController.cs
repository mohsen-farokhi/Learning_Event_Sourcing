using AuctionManagement.Application.Contracts;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;

namespace AuctionManagement.Gateways.RestApi
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionsController : Controller
    {
        private readonly ICommandBus _commandBus;

        public AuctionsController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OpenAuction command)
        {
            await _commandBus.Dispatch(command);

            return Ok();
        }

        [HttpPost("{id}/Bids")]
        public async Task<IActionResult> Post(Guid id, PlaceBid command)
        {
            command.AuctionId = id;
            await _commandBus.Dispatch(command);

            return Ok();
        }
    }
}