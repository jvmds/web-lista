using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLista.Domain.Entities;

namespace WebLista.Infrastructure.EntitiesConfiguration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(t => t.ItemId);
        builder.Property(t => t.Name)
                        .HasMaxLength(100)
                        .IsRequired();
        builder.Property(t => t.Description)
                        .HasMaxLength(500)
                        .IsRequired();
        builder.Property(t => t.ReservationEmail)
                        .HasMaxLength(256)
                        .IsRequired(false);
        builder.Property(t => t.UrlImage)
                        .HasMaxLength(500)
                        .IsRequired();
        builder.Property(t => t.Reserved)
                        .HasDefaultValue(false)
                        .IsRequired();
        builder.HasOne(t => t.GiftList).
                        WithMany(h => h.Items)
                        .HasForeignKey(t => t.GirftListId);
    }
}