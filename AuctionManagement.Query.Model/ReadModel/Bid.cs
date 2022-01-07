namespace AuctionManagement.Query.Model.ReadModel
{
    public class Bid
    {
        public long Id { get; set; }
        public Guid AuctionId { get; set; }
        public Auction Auction { get; set; }
        public long BidderId { get; set; }
        public long Amount { get; set; }
    }
}
