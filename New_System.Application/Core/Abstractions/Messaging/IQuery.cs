using MediatR;

namespace New_System.Application.Core.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}
