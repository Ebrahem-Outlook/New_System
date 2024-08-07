using MediatR;
using New_System.Application.Core.Messaging;
using New_System.Domain.Products;

namespace New_System.Application.Products.Queries.GetAll;

public sealed record GetAllProductsQuery() : IQuery<List<Product>>;
