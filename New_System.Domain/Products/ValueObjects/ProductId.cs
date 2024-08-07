using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    private ProductId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ProductId Create()
    {
        return new ProductId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
