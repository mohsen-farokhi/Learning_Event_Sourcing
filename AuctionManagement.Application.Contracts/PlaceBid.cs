namespace AuctionManagement.Application.Contracts
{
    public class PlaceBid
    {
        public Guid AuctionId { get; set; }
        public long BidAmount { get; set; }
        public long BidderId { get; set; }
    }
}