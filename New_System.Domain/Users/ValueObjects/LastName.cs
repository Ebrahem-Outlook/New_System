using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Users.ValueObjects;

public sealed class LastName : ValueObject
{
    private LastName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static LastName Create(string lastName)
    {
        return new LastName(lastName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}