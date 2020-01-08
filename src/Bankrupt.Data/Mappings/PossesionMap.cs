using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankrupt.Data.Model.Repository
{
    public class PossesionMap : IEntityTypeConfiguration<PossesionInfo>
    {
        public void Configure(EntityTypeBuilder<PossesionInfo> builder)
        {
            builder.Property(p => p.BoardGame).IsRequired();
            builder.Property(p => p.Player).IsRequired();
            builder.Property(p => p.BoardHouse).IsRequired();
        }
    }
}
