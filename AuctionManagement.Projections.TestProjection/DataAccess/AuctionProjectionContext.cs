using AuctionManagement.Query.Model.Mappings;
using AuctionManagement.Query.Model.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace AuctionManagement.Projections.TestProjection.DataAccess
{
    internal class AuctionProjectionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AuctionReadDb;User ID=SA;Password=P@ssw0rd;Persist Security Info=True;");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BidMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
