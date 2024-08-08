using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class Contect : ValueObject
{
    private Contect(string value) => Value = value;

    public string Value { get; }

    public static Contect Create(string value)
    {
        return new Contect(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
