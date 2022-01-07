using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Projections.TestProjection.DataAccess;
using AuctionManagement.Projections.TestProjection.Framework;
using AuctionManagement.Query.Model.ReadModel;

namespace AuctionManagement.Projections.TestProjection.Handlers
{
    internal class AuctionOpenedHandler : IEventHandler<AuctionOpened>
    {
        private readonly AuctionProjectionContext _dbContext;

        public AuctionOpenedHandler(AuctionProjectionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(AuctionOpened domainEvent)
        {
            var auction = new Auction
            {
                Id = domainEvent.Id,
                SellerId = domainEvent.SellerId,
                EndDate = domainEvent.EndDate,
                Product = domainEvent.Product,
                StartingPrice = domainEvent.StartingPrice,
            };

            _dbContext.Add(auction);
            _dbContext.SaveChanges();
        }
    }
}
