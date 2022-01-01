using AuctionManagement.Domain.Models.Auctions.Events;
using AuctionManagement.Domain.Models.Auctions.ValueObjects;
using Framework.Domain;

namespace AuctionManagement.Domain.Models.Auctions
{
    public partial class Auction : AggregateRoot<long>
    {
        private Auction() { }

        public Auction
            (long sellerId, long startingPrice, string product, DateTime endDate)
        {
            if (endDate < DateTime.Now)
            {
                throw new Exception("End date cant be past");
            }

            ApplyAndPublish(new AuctionOpened(Id, sellerId, startingPrice, endDate, product));
        }

        public long SellerId { get; private set; }
        public long StartingPrice { get; private set; }
        public string Product { get; set; }
        public DateTime EndDate { get; private set; }
        public WinningBid WinningBid { get; private set; }

        public void PlaceBid(long bidderId, long amount)
        {
            var maxBid = StartingPrice;

            if (firstBid() == false)
            {
                maxBid = WinningBid.Amount;
            }

            if (maxBid >= amount)
            {
                throw new Exception("Invalid amount");
            }

            if (SellerId == bidderId)
            {
                throw new Exception("Invalid bidder");
            }

            // ...

            ApplyAndPublish(new BidPlaced(Id, amount, bidderId));
        }

        private bool firstBid()
        {
            return WinningBid == null;
        }

    }

}
