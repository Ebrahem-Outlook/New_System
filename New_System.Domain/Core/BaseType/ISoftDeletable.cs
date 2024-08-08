namespace New_System.Domain.Core.BaseType;

public interface ISoftDeletable
{
    bool IsDeletable { get; }

    DateTime? DeletedDate { get;  }
}
