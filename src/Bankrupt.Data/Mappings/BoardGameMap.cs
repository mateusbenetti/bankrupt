using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankrupt.Data.Model.Repository
{
    public class BoardGameMap : IEntityTypeConfiguration<BoardGameInfo>
    {
        public void Configure(EntityTypeBuilder<BoardGameInfo> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Round).IsRequired();
            builder.Property(p => p.Date).IsRequired();
        }
    }
}