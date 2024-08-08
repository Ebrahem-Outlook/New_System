using New_System.Application.Core.Data;
using New_System.Domain.Orders;

namespace New_System.Infrastructure.Repositories;

internal sealed class OrderRepository(IDbContext dbContext) : IOrderRepository
{
}
