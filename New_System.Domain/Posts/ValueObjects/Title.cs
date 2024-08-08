using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class Title : ValueObject
{
    public Title(string value) => Value = value;

    public string Value { get; }

    public static Title Create(string title)
    {
        return new Title(title);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
