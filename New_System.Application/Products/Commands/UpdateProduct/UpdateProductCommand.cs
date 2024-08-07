using MediatR;
using New_System.Application.Core.Messaging;

namespace New_System.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Guid ProductId, string Name, string Description, decimal Price) : ICommand<Unit>;
