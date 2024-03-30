using WebLista.Domain.Entities;

namespace WebLista.Domain.Abstractions;

public interface IGiftListRepository
{
    public Task<GiftList> AddAsync(GiftList giftList);
    public Task UpdateAsync(GiftList giftList);
    public Task DeleteAsync(GiftList giftList);
    public Task<GiftList> GetAsync(int giftListId);
}