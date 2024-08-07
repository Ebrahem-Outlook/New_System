namespace New_System.Domain.Products;

public interface IProductRepository
{
    // Commnads.
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task Update(Product product, CancellationToken cancellationToken);
    Task Delete(Product product, CancellationToken cancellationToken);

    // Queries.
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Product>> GetByNameAsync(string name, CancellationToken cancellationToken);
}
