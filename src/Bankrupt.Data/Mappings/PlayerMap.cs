using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankrupt.Data.Model.Repository
{
    public class PlayerMap : IEntityTypeConfiguration<PlayerInfo>
    {
        public void Configure(EntityTypeBuilder<PlayerInfo> builder)
        {
            builder.Property(p => p.Id).IsRequired();
        }
    }
}
