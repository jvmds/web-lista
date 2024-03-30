using WebLista.Domain.Abstractions;
using WebLista.Domain.Entities;
using WebLista.Infrastructure.Context;

namespace WebLista.Infrastructure.Repositories;

public class GiftListRepository(WebListaDbContext context) : IGiftListRepository
{
    private WebListaDbContext _context = context;

    public async Task<GiftList> AddAsync(GiftList giftList)
    {
        await _context.GiftLists.AddAsync(giftList);
        await _context.SaveChangesAsync();

        return giftList;
    }

    public async Task UpdateAsync(GiftList giftList)
    {
        _context.GiftLists.Update(giftList);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(GiftList giftList)
    {
        _context.GiftLists.Remove(giftList);
        await _context.SaveChangesAsync();
    }

    public async Task<GiftList> GetAsync(int giftListId)
    {
        var giftList = await _context.GiftLists.FindAsync(giftListId);

        if (giftList is null)
        {
            throw new InvalidOperationException("GiftList not found");
        }

        return giftList;
    }
}