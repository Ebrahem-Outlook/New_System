using New_System.Application.Core.Messaging;
using New_System.Domain.Products;

namespace New_System.Application.Products.Queries.GetById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdAsync(request.ProductId, cancellationToken)
            ?? throw new NullReferenceException("User with specified Id does't exsit.");
    }
}
