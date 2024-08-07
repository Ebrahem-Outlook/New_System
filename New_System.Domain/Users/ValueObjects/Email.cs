using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Users.ValueObjects;

public sealed class Email : ValueObject
{
    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Email Create(string email)
    {
        return new Email(email);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
