using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Orders.ValueObjects;

public sealed class CustomerId : ValueObject
{
    public CustomerId(Guid value) => Value = value;

    public Guid Value { get; }

    public static CustomerId New() => new CustomerId(Guid.NewGuid());

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
