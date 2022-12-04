namespace Application.Common;

using Domain.Exceptions;

using Serilog;

using App_CleanArchitecture.Helpers;

public enum Status
{
    Ok,
    NotFound,
    Exception
}

public record QResult
{
    protected QResult() { }
    public QResult(object? value)
    {
        Value = value;
        if (value is null)
        {
            Result = new ApiResponse(value?.GetType().Name + ".NotFound", null, 200);
            Status = Status.NotFound;
            Log.Warning("Message:{Message}", Result.Message);
        }
        else
        {
            Result = new(value, 200);
            Status = Status.Ok;
        }
    }

    public QResult(QResult qResult)
    {
        Value = qResult.Value;
        Result = qResult.Result;
        Exception = qResult.Exception;
        Status = qResult.Status;
    }

    public QResult(Exception exception)
    {
        while (exception.InnerException is not null)
            exception = exception.InnerException;

        Exception = AutoWrapperHelper.GenerateError(exception);
        Value = default;
        Status = Status.Exception;
        Result = default!;
        //   Log.Error("Message: {Message}\n", exception.Message, exception.StackTrace);
    }

    public QResult(string exceptionMessage, int statusCode = 400)
    {

        Exception = AutoWrapperHelper.GenerateError(new QException(exceptionMessage, statusCode));
        Value = default;
        Status = Status.Exception;
        Result = default!;
        Log.Error("{exceptionMessage}", exceptionMessage);
    }

    public object? Value { get; set; }

    public ApiResponse? Result { get; set; }
    public Status Status { get; set; }

    public Exception? Exception { get; set; }
}

public record QResult<T> : QResult
{
    public QResult(T? value, string? notFoundMessage = default, string? okMessage = default)
    {
        Value = value;



        if (value is null)
        {
            Result = new ApiResponse(notFoundMessage ?? $"{typeof(T).Name}.NotFound", null, 200);
            Exception = new ApiException(notFoundMessage ?? $"{typeof(T).Name}.NotFound");
            Status = Status.NotFound;
            Log.Warning("Message:{Message}", Result.Message);
        }
        else
        {

            Result = okMessage is null ? new(value, 200) : new(okMessage, value, 200);
            Status = Status.Ok;
        }

    }

    public QResult(QResult qResult) : base(qResult) { }

    public QResult(Exception exception) : base(exception) { }

    public QResult(string exceptionMessage, int statusCode = 400) : base(exceptionMessage, statusCode) { }

    public static implicit operator QResult<T?>(T t)
    {
        return QResults.From(t);
    }

    public static implicit operator QResult<T?>(Exception e)
    {
        return QResults.Exception<T>(e);
    }



    public new T? Value { get; set; }

}

public record QResults
{
    public static QResult<T> OK<T>(T value, string? okMessage = default)
    {
        return new QResult<T>(value, default, okMessage);
    }

    public static QResult<T?> NotFound<T>(string? notFoundMessage = default)
    {
        return new QResult<T?>(default, notFoundMessage, default);
    }

    public static QResult<T?> Exception<T>(Exception exception)
    {
        return new QResult<T?>(exception: exception);
    }
    public static QResult<T?> Exception<T>(string exceptionmessage, int statusCode = 400)
    {
        return new QResult<T?>(exceptionmessage, statusCode);
    }
    public static QResult<T?> From<T>(T? value, string? notFoundMessage = default, string? okMessage = default)
    {
        return new QResult<T?>(value, notFoundMessage, okMessage);
    }

    public static QResult<IEnumerable<T>?> From<T>(IEnumerable<T>? value, string? notFoundMessage = default, string? okMessage = default)
    {
        return new QResult<IEnumerable<T>?>(value, notFoundMessage, okMessage);
    }
    public static QResult<T?> InfoMessage<T>(T value, string? InfoMessage = default, string? okMessage = default)
    {
        return new QResult<T?>(value, InfoMessage, okMessage);
    }
    public static QResult<T?> From<T>(QResult qResult)
    {
        return new QResult<T?>(qResult);
    }

}