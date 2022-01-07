using AuctionManagement.Query.Contracts;
using AuctionManagement.Query.Model;

namespace AuctionManagement.Query.Services
{
    public class AuctionService : IAuctionQueryService
    {
        private readonly AuctionDbContext _dbContext;

        public AuctionService(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<AuctionDto> GetLatestAuctions(int count)
        {
            return null;
        }
    }
}