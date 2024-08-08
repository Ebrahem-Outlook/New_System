using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Orders.ValueObjects;

public sealed class OrderItemId : ValueObject
{
    private OrderItemId(Guid value) => Value = value;

    public Guid Value { get; }

    public static OrderItemId Create()
    {
        return new OrderItemId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
