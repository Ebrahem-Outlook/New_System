using Microsoft.EntityFrameworkCore;
using New_System.Application.Core.Data;
using New_System.Domain.Users;

namespace New_System.Infrastructure.Repositories;

internal sealed class UserRepository(IDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await dbContext.Set<User>().AddAsync(user, cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Set<User>().Update(user);

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Set<User>().Remove(user);

        await Task.CompletedTask;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>().ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>().FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task<List<User>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>().Where(user => user.FirstName == name).ToListAsync(cancellationToken);
    }
}
