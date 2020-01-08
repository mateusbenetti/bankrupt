using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankrupt.Data.Model.Repository
{
    public class BoardHouseMap : IEntityTypeConfiguration<BoardHouseInfo>
    {
        public void Configure(EntityTypeBuilder<BoardHouseInfo> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Sequential).IsRequired();
            builder.Property(p => p.PurchaseValue).IsRequired();
            builder.Property(p => p.RentValue).IsRequired();
            builder.Property(p => p.BoardGame).IsRequired();
        }
    }
}
