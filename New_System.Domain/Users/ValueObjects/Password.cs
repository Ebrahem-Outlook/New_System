using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Users.ValueObjects;

public sealed class Password : ValueObject
{
    private Password(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Password Create(string value)
    {
        return new Password(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
