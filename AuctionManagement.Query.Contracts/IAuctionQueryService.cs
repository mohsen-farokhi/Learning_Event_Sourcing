namespace AuctionManagement.Query.Contracts
{
    public interface IAuctionQueryService
    {
        IList<AuctionDto> GetLatestAuctions(int count);
    }
}
