using WebLista.Domain.Abstractions;
using WebLista.Domain.Entities;
using WebLista.Infrastructure.Context;

namespace WebLista.Infrastructure.Repositories;

public class StoreRepository(WebListaDbContext context) : IStoreRepository
{
    private WebListaDbContext _context = context;
    
    public async Task<Store> AddAsync(Store store)
    {
        await _context.Stores.AddAsync(store);
        await _context.SaveChangesAsync();

        return store;
    }

    public async Task UpdateAsync(Store store)
    {
        _context.Stores.Update(store);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Store store)
    {
        _context.Stores.Remove(store);
        await _context.SaveChangesAsync();
    }

    public async Task<Store> GetAsync(int storeId)
    {
        var store = await _context.Stores.FindAsync(storeId);

        if (store is null)
        {
            throw new InvalidOperationException("Store not found");
        }

        return store;
    }
}