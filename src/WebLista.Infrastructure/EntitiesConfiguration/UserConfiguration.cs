using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLista.Domain.Entities;

namespace WebLista.Infrastructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(t => t.UserId);
        builder.Property(t => t.Email)
                        .HasMaxLength(256)
                        .IsRequired();
        builder.Property(t => t.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();
        builder.Property(t => t.LastName)
                        .HasMaxLength(50)
                        .IsRequired();
        builder.Property(t => t.IdentityUserId)
                        .HasMaxLength(255)
                        .IsRequired();
    }
}