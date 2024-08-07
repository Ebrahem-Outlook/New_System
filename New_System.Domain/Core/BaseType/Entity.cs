namespace New_System.Domain.Core.BaseType;

public abstract class Entity<TId> : Entity, IEquatable<Entity<TId>?> 
    where TId : class
{
    protected Entity(TId id) => Id = id ?? throw new ArgumentNullException(nameof(id));

    protected Entity() { }

    public TId Id { get; } = default!;

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public bool Equals(Entity<TId>? other)
    {
        return other is not null &&
               EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return EqualityComparer<Entity<TId>>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}

public abstract class Entity
{
}
