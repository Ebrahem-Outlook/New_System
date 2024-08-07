using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using New_System.Domain.Users;
using Newtonsoft.Json;

namespace New_System.Infrastructure.Caching;

/// <summary>
/// 
/// </summary>
internal sealed class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decorated;
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _cacheOptions;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="decorated"></param>
    /// <param name="cache"></param>
    public CachedUserRepository(IDistributedCache cache, IUserRepository decorated)
    {
        _cache = cache;
        _decorated = decorated;
        _cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5), // Cache items for 30 minutes
            SlidingExpiration = TimeSpan.FromMinutes(10) // Reset the expiration time if accessed within 10 minutes
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _decorated.AddAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        await _decorated.UpdateAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        await _decorated.DeleteAsync(user, cancellationToken);
        string key = $"Key-{user.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        string key = "Key-GetAll";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<List<User>>(cachedData) ?? [];
        }

        List<User> users =await _decorated.GetAllAsync(cancellationToken);

        if (!users.IsNullOrEmpty())
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(users), _cacheOptions, cancellationToken);
        }

        return users;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<User>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        string key = $"Key-Name-{name}";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<List<User>>(cachedData) ?? [];
        }

        List<User> users = await _decorated.GetByNameAsync(name, cancellationToken);

        if (!users.IsNullOrEmpty())
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(users), _cacheOptions, cancellationToken);
        }

        return users;
    }
}
