using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Projections.TestProjection.DataAccess;
using AuctionManagement.Projections.TestProjection.Framework;
using AuctionManagement.Query.Model.ReadModel;

namespace AuctionManagement.Projections.TestProjection.Handlers
{
    internal class BidPlacedHandler : IEventHandler<BidPlaced>
    {
        private readonly AuctionProjectionContext _dbContext;

        public BidPlacedHandler(AuctionProjectionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(BidPlaced domainEvent)
        {
            var bid = new Bid
            {
                Amount = domainEvent.BidAmount,
                AuctionId = domainEvent.AuctionId,
                BidderId = domainEvent.BidderId,
            };

            _dbContext.Add(bid);
            _dbContext.SaveChanges();
        }
    }
}
