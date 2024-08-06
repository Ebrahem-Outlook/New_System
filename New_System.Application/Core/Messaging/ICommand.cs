using MediatR;

namespace New_System.Application.Core.Messaging;

public interface ICommand : IRequest
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
