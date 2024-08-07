using Microsoft.EntityFrameworkCore;
using New_System.Application.Core.Data;
using New_System.Domain.Products;

namespace New_System.Infrastructure.Repositories;

internal sealed class ProductRepository(IDbContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await dbContext.Set<Product>().AddAsync(product, cancellationToken);
    }

    public async Task Update(Product product, CancellationToken cancellationToken)
    {
        dbContext.Set<Product>().Update(product);

        await Task.CompletedTask;
    }

    public async Task Delete(Product product, CancellationToken cancellationToken)
    {
        dbContext.Set<Product>().Remove(product);

        await Task.CompletedTask;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Product>().FindAsync(id, cancellationToken);
    }

    public async Task<List<Product>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Product>().Where(product => product.Name == name).ToListAsync(cancellationToken);
    }
}
