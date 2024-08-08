namespace New_System.Domain.Core.BaseType;

public interface IAuditable
{
    DateTime CreatedDate { get; }
    DateTime? ModifiedDate { get; }
}
