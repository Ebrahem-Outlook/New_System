using MediatR;
using New_System.Application.Core.Messaging;

namespace New_System.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand<Unit>;
