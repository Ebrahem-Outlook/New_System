using Microsoft.Extensions.Caching.Distributed;
using New_System.Domain.Users;
using Newtonsoft.Json;

namespace New_System.Infrastructure.Caching;

internal sealed class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _cacheOptions;

    public CachedUserRepository(IUserRepository decorated, IDistributedCache cache)
    {
        _decorated = decorated;
        _cache = cache;
        _cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30), // Cache items for 30 minutes
            SlidingExpiration = TimeSpan.FromMinutes(10) // Reset the expiration time if accessed within 10 minutes
        };
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _decorated.AddAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        await _decorated.UpdateAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        await _decorated.DeleteAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        string key = "Key-GetAll";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<List<User>>(cachedData) ?? [];
        }

        List<User> users =await _decorated.GetAllAsync(cancellationToken);

        await _cache.SetStringAsync(key, JsonConvert.SerializeObject(users), _cacheOptions, cancellationToken);

        return users;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        string key = $"Key-{email}";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<User>(cachedData);
        }

        User? user = await _decorated.GetByEmailAsync(email, cancellationToken);
        if (user is not null)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(user), _cacheOptions, cancellationToken);
        }

        return user;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        string key = $"Key-{id}";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<User>(cachedData);
        }

        User? user = await _decorated.GetByIdAsync(id, cancellationToken);
        if(user is not null)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(user), _cacheOptions, cancellationToken);
        }

        return user;
    }

    public async Task<List<User>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        string key = $"Key-Name-{name}";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<List<User>>(cachedData) ?? [];
        }

        List<User> users = await _decorated.GetByNameAsync(name, cancellationToken);

        await _cache.SetStringAsync(key, JsonConvert.SerializeObject(users), _cacheOptions, cancellationToken);

        return users;
    }
}
