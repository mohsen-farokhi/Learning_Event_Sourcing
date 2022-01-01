using Framework.Domain;

namespace AuctionManagement.Domain.Models.Auctions.Events
{
    public class BidPlaced : DomainEvent
    {
        public BidPlaced(long auctionId, long bidAmount, long bidderId)
        {
            AuctionId = auctionId;
            BidAmount = bidAmount;
            BidderId = bidderId;
        }

        public long AuctionId { get; private set; }
        public long BidAmount { get; private set; }
        public long BidderId { get; private set; }
    }
}
