public class Result<TSuccess, TError>
{
    public bool IsSuccess { get; }
    public TSuccess? Value { get; }
    public TError? Error { get; }

    private Result(TSuccess value)
    {
        IsSuccess = true;
        Value = value;
        Error = default;
    }

    private Result(TError error)
    {
        IsSuccess = false;
        Error = error;
        Value = default;
    }

    public static Result<TSuccess, TError> Success(TSuccess value) => new(value);
    public static Result<TSuccess, TError> Failure(TError error) => new(error);

    public void Match(Action<TSuccess> onSuccess, Action<TError> onError)
    {
        if (IsSuccess)
            onSuccess(Value!);
        else
            onError(Error!);
    }

    public TResult Match<TResult>(Func<TSuccess, TResult> onSuccess, Func<TError, TResult> onError)
    {
        return IsSuccess ? onSuccess(Value!) : onError(Error!);
    }
}