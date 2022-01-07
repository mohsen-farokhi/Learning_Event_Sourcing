using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Models.Auctions;
using Framework.Application;

namespace AuctionManagement.Application
{
    public class AuctionCommandHandlers :
        ICammandHandler<OpenAuction>,
        ICammandHandler<PlaceBid>
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionCommandHandlers(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task Handle(OpenAuction command)
        {
            var id = Guid.NewGuid();

            var auction =
                new Auction
                (id, command.SellerId, command.StartingPrice,
                command.Product, command.EndDate);

            await _auctionRepository.Add(auction);
        }

        public async Task Handle(PlaceBid command)
        {
            var auction = 
                await _auctionRepository.Get(command.AuctionId);

            auction.PlaceBid(command.BidderId, command.BidAmount);

            await _auctionRepository.Update(auction);
        }
    }
}