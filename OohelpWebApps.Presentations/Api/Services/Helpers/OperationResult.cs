namespace OohelpWebApps.Presentations.Api.Services.Helpers;
public class OperationResult<T>
{
    public OperationResult(T value)
    {
        Value = value;
        Success = true;
    }
    public OperationResult(Exception error)
    {
        Error = error;
        Success = false;
    }
    public T Value { get; }
    public Exception Error { get; }
    public bool Success { get; }

    public static OperationResult<T> NotFound() =>
        new OperationResult<T>(new Exceptions.ApiException(Contracts.Common.Enums.Status.NotFound));

    public static OperationResult<T> RequestDenied() =>
        new OperationResult<T>(new Exceptions.ApiException(Contracts.Common.Enums.Status.RequestDenied));

    public static OperationResult<T> InvalidRequest() =>
        new OperationResult<T>(new Exceptions.ApiException(Contracts.Common.Enums.Status.InvalidRequest));

    public static OperationResult<T> DatabaseError() =>
        new OperationResult<T>(new Exceptions.ApiException(Contracts.Common.Enums.Status.DatabaseError));

    public static OperationResult<T> DatabaseError(string message) =>
        new OperationResult<T>(new Exceptions.ApiException(Contracts.Common.Enums.Status.DatabaseError, message));

}
