using WebLista.Domain.Entities;

namespace WebLista.Domain.Abstractions;

public interface IItemRepository
{
    public Task<Item> AddAsync(Item item);
    public Task UpdateAsync(Item item);
    public Task DeleteAsync(Item item);
    public Task<Item> GetAsync(int itemId);
    public Task<IList<Item>> GetItemsLinkedToGiftListAsync(int giftListId);
}