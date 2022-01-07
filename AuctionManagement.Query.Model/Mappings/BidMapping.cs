using AuctionManagement.Query.Model.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionManagement.Query.Model.Mappings
{
    public class BidMapping : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bids");

            builder.HasOne(c => c.Auction)
                .WithMany()
                .HasForeignKey(c => c.AuctionId);
        }
    }
}
