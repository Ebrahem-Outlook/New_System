using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Orders.ValueObjects;

public sealed class OrderId : ValueObject
{
    private OrderId(Guid value) => Value = value;

    public Guid Value { get; }

    public static OrderId Create()
    {
        return new OrderId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
