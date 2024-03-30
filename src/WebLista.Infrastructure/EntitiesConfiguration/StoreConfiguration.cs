using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLista.Domain.Entities;

namespace WebLista.Infrastructure.EntitiesConfiguration;

public class StoreConfiguration: IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(t => t.StoreId);
        builder.Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();
        builder.Property(t => t.Link)
                        .HasMaxLength(500)
                        .IsRequired();
        builder.HasOne(t => t.Item)
                        .WithMany(h => h.Stores)
                        .HasForeignKey(t => t.ItemId);
    }
}