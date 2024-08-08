using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Orders.ValueObjects;

public sealed class OrderNumber : ValueObject
{
    private OrderNumber(string value) => Value = value;

    public string Value { get; }

    public static OrderNumber Create(string value)
    {
        // validation...
        return new OrderNumber(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
