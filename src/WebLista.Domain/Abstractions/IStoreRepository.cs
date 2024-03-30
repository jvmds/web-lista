using WebLista.Domain.Entities;

namespace WebLista.Domain.Abstractions;

public interface IStoreRepository
{
    public Task<Store> AddAsync(Store store);
    public Task UpdateAsync(Store store);
    public Task DeleteAsync(Store store);
    public Task<Store> GetAsync(int storeId);
}