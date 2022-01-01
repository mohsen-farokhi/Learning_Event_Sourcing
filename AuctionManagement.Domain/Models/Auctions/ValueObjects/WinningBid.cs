namespace AuctionManagement.Domain.Models.Auctions.ValueObjects
{
    public class WinningBid
    {
        public WinningBid(long bidderId, long amount)
        {
            BidderId = bidderId;
            Amount = amount;
        }

        public long BidderId { get; private set; }
        public long Amount { get; private set; }
    }

}
