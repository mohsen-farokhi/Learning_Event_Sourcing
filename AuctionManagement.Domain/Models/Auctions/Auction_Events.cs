using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Domain.Models.Auctions.ValueObjects;
using Framework.Domain;

namespace AuctionManagement.Domain.Models.Auctions
{
    public partial class Auction
    {
        public override void Apply(DomainEvent @event)
        {
            when((dynamic)@event);
        }

        private void when(BidPlaced @event)
        {
            WinningBid = new WinningBid(@event.BidderId, @event.BidAmount);
        }

        private void when(AuctionOpened @event)
        {
            Id = @event.Id;
            SellerId = @event.SellerId;
            StartingPrice = @event.StartingPrice;
            Product = @event.Product;
            EndDate = @event.EndDate;
        }
    }
}
