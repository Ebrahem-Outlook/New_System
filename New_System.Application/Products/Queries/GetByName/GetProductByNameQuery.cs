using New_System.Application.Core.Messaging;
using New_System.Domain.Products;

namespace New_System.Application.Products.Queries.GetByName;

public sealed record GetProductByNameQuery(string Name) : IQuery<List<Product>>;
