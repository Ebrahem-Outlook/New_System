using New_System.Application.Core.Data;
using New_System.Domain.Messages;

namespace New_System.Infrastructure.Repositories;

internal sealed class MessageRepository(IDbContext dbContext) : IMessageRepository
{
}
