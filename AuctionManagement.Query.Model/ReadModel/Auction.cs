namespace AuctionManagement.Query.Model.ReadModel
{
    public class Auction
    {
        public Guid Id { get; set; }
        public long SellerId { get; set; }
        public long StartingPrice { get; set; }
        public string Product { get; set; }
        public DateTime EndDate { get; set; }
        public long? WinnerBiedderId { get; set; }
        public long? WinnerBidderAmount { get; set; }
    }
}
