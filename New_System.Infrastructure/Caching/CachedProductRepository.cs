using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using New_System.Domain.Products;
using Newtonsoft.Json;

namespace New_System.Infrastructure.Caching;

/// <summary>
/// 
/// </summary>
internal sealed class CachedProductRepository : IProductRepository
{
    private readonly IDistributedCache _cache;
    private readonly IProductRepository _decorated;
    private readonly DistributedCacheEntryOptions _cacheOptions;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cache"></param>
    /// <param name="decorated"></param>
    public CachedProductRepository(IDistributedCache cache, IProductRepository decorated)
    {
        _cache = cache;
        _decorated = decorated;
        _cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),  // Cache items for 30 minutes
            SlidingExpiration = TimeSpan.FromMinutes(3), // Reset the expiration time if accessed within 10 minutes
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _decorated.AddAsync(product, cancellationToken);
        string key = $"Key-{product.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Update(Product product, CancellationToken cancellationToken)
    {
        await _decorated.Update(product, cancellationToken);
        string key = $"Key-{product.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Delete(Product product, CancellationToken cancellationToken)
    {
        await _decorated.Delete(product, cancellationToken);
        string key = $"Key-{product.Id}";
        await _cache.RemoveAsync(key, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        string key = "Key-AllProducts";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<List<Product>>(cachedData) ?? [];
        }

        List<Product> products= await _decorated.GetAllAsync(cancellationToken);

        if (!products.IsNullOrEmpty())
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(products), cancellationToken);
        }

        return products;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        string key = $"Key-{id}";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<Product>(cachedData);
        }

        Product? product = await _decorated.GetByIdAsync(id, cancellationToken);

        if (product is not null)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(product), cancellationToken);
        }

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Product>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        string key = "Key-Product-Name";
        string? cachedData = await _cache.GetStringAsync(key, cancellationToken);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<List<Product>>(cachedData) ?? [];
        }

        List<Product> products = await _decorated.GetByNameAsync(name, cancellationToken);

        if (!products.IsNullOrEmpty())
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(products), cancellationToken);
        }

        return products;
    }
}
