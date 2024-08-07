using New_System.Application.Core.Messaging;
using New_System.Domain.Products;

namespace New_System.Application.Products.Queries.GetById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<Product>;
