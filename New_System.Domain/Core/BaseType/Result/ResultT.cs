namespace New_System.Domain.Core.BaseType.Result;

internal class Result<TValue> : Result
{
    protected Result(bool isSuccess, Error error) : base(isSuccess, error)
    {
    }
}
