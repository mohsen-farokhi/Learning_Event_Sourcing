using Framework.Domain;

namespace AuctionManagement.Domain.Models.Auctions.Events
{
    public class AuctionOpened : DomainEvent
    {
        public AuctionOpened
            (long id, long sellerId, long startingPrice, DateTime endDate, string product)
        {
            Id = id;
            SellerId = sellerId;
            StartingPrice = startingPrice;
            EndDate = endDate;
            Product = product;
        }

        public long Id { get; private set; }
        public long SellerId { get; private set; }
        public long StartingPrice { get; private set; }
        public string Product { get; set; }
        public DateTime EndDate { get; private set; }
    }
}
