using AuctionManagement.Domain.Models.Auctions;
using Framework.Domain;

namespace AuctionManagement.Persistance.ES
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly IEventSourceRepository<Auction, Guid> _eventSourceRepository;

        public AuctionRepository
            (IEventSourceRepository<Auction, Guid> eventSourceRepository)
        {
            _eventSourceRepository = eventSourceRepository;
        }
        public async Task Add(Auction auction)
        {
            await _eventSourceRepository.AppendEvents(auction);
        }

        public async Task<Auction> Get(Guid id)
        {
            var auction = 
                await _eventSourceRepository.GetById(id);

            return auction;
        }

        public async Task Update(Auction auction)
        {
            await _eventSourceRepository.AppendEvents(auction);
        }
    }
}