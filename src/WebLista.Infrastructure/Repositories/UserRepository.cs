using WebLista.Domain.Abstractions;
using WebLista.Domain.Entities;
using WebLista.Infrastructure.Context;

namespace WebLista.Infrastructure.Repositories;

public class UserRepository(WebListaDbContext webListaDbContext) : IUserRepository
{
    private WebListaDbContext _context = webListaDbContext;

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }

        return user;
    }
}