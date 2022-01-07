using Framework.Domain;

namespace AuctionManagement.Domain.Contracts.Auctions.Events
{
    public class BidPlaced : DomainEvent
    {
        public BidPlaced(Guid auctionId, long bidAmount, long bidderId)
        {
            AuctionId = auctionId;
            BidAmount = bidAmount;
            BidderId = bidderId;
        }

        public Guid AuctionId { get; private set; }
        public long BidAmount { get; private set; }
        public long BidderId { get; private set; }
    }
}
