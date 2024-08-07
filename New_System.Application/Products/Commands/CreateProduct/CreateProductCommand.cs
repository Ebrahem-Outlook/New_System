using MediatR;
using New_System.Application.Core.Messaging;

namespace New_System.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string Description, decimal Price) : ICommand<Unit>;
