namespace AuctionManagement.Application.Contracts
{
    public class OpenAuction
    {
        public long SellerId { get; set; }
        public long StartingPrice { get; set; }
        public string Product { get; set; }
        public DateTime EndDate { get; set; }
    }
}