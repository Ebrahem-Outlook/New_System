using New_System.Application.Core.Messaging;
using New_System.Domain.Products;

namespace New_System.Application.Products.Queries.GetByName;

internal sealed class GetProductByNameQueryHandler : IQueryHandler<GetProductByNameQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByNameQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByNameAsync(request.Name, cancellationToken);
    }
}
