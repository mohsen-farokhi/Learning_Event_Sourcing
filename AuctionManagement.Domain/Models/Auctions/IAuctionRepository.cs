namespace AuctionManagement.Domain.Models.Auctions
{
    public interface IAuctionRepository
    {
        Task<Auction> Get(Guid id);
        Task Add(Auction auction);
        Task Update(Auction auction);
    }
}
