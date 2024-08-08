using New_System.Domain.Core.BaseType;
using New_System.Domain.Orders.ValueObjects;

namespace New_System.Domain.Orders;

public sealed class Order : AggregateRoot<OrderId>
{
    public OrderNumber OrderNumber { get; } = default!;
    public DateTime OrderDate { get; }
    public CustomerId CustomerId { get; } = default!;
    public List<OrderItem> OrderItems { get; private set; } = [];
}
