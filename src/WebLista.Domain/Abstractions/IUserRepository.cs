using WebLista.Domain.Entities;

namespace WebLista.Domain.Abstractions;

public interface IUserRepository
{
    public Task<User> AddAsync(User user);
    public Task UpdateAsync(User user);
    public Task DeleteAsync(User user);
    public Task<User> GetAsync(int userId);
}