using Microsoft.EntityFrameworkCore;
using WebLista.Domain.Entities;

namespace WebLista.Infrastructure.Context;

public class WebListaDbContext : DbContext
{
    public WebListaDbContext(DbContextOptions<WebListaDbContext> options) : base(options)
    {
        
    }
    public DbSet<GiftList> GiftLists { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebListaDbContext).Assembly);
    }
}