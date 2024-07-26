using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLista.Domain.Entities;

namespace WebLista.Infrastructure.EntitiesConfiguration;

public class GiftListConfiguration : IEntityTypeConfiguration<GiftList>
{
    public void Configure(EntityTypeBuilder<GiftList> builder)
    {
        builder.HasKey(t => t.GiftLisId);
        builder.Property(t => t.Name)
                        .HasMaxLength(100)
                        .IsRequired();
        builder.HasIndex(t => t.UserId);
    }
}