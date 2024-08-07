namespace New_System.Domain.Core.BaseType;

public abstract class ValueObject
{
    protected abstract IEnumerable<Object> GetEqualityComponents();

    public bool Equals(ValueObject? other)
    {
        if(other is null)
        {
            return false;
        }

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents()); 
    }

    public override bool Equals(object? obj)
    {
        if (obj is ValueObject other)
        {
            return Equals(other);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, component) => current * 23 + (component?.GetHashCode() ?? 0));
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);    
    }
}
