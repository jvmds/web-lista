using WebLista.Domain.Abstractions;
using WebLista.Domain.Entities;
using WebLista.Infrastructure.Context;

namespace WebLista.Infrastructure.Repositories;

public class ItemRepository(WebListaDbContext context) : IItemRepository
{
    private WebListaDbContext _context = context;
    
    public async Task<Item> AddAsync(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Item item)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Item> GetAsync(int itemId)
    {
        var item = await _context.Items.FindAsync(itemId);

        if (item is null)
        {
            throw new InvalidOperationException("Item not found");
        }

        return item;
    }
}