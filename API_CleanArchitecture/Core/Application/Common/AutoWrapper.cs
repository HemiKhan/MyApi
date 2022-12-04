namespace App_CleanArchitecture.Helpers;

using System;
using System.Text;

using Domain.Exceptions;

using Serilog;

/**ApiResponse Overload Constructors **/
/**
ApiResponse(string message, object result = null, int statusCode = 200, string apiVersion = "1.0.0.0")
ApiResponse(object result, int statusCode = 200)
ApiResponse(int statusCode, object apiError)
ApiResponse()
**/

/**ApiException Overload Constructors **/
/** 
   ApiException(string message, int statusCode = 400, string errorCode = "", string refLink = "")
   ApiException(IEnumerable<ValidationError> errors, int statusCode = 400)
   ApiException(System.Exception ex, int statusCode = 500)
   ApiException(object custom, int statusCode = 400)
***/

/**ApiProblemDetailsException Overload Constructors **/
/** 
ApiProblemDetailsException(int statusCode)
ApiProblemDetailsException(string title, int statusCode)
ApiProblemDetailsException(ProblemDetails details)
ApiProblemDetailsException(ModelStateDictionary modelState, int statusCode = Status422UnprocessableEntity)
***/


public class MapResponseObject
{
    [AutoWrapperPropertyMap(Prop.Result)]
    public object? Payload { get; set; }


    [AutoWrapperPropertyMap(Prop.ResponseException)]
    public object? ErrorResponse { get; set; }

    [AutoWrapperPropertyMap(Prop.ResponseException_ExceptionMessage)]
    public string? Message { get; set; }

    [AutoWrapperPropertyMap(Prop.ResponseException_Details)]
    public string? Trace { get; set; }
}

public class AutoWrapper
{
    public int Code { get; set; }
    public string? Message { get; set; }
    public object? Payload { get; set; }
    public DateTime SentDate { get; set; }
    public Pagination? Pagination { get; set; }

    public AutoWrapper(DateTime sentDate,
                               object? payload = null,
                               string message = "",
                               int statusCode = 200,
                               Pagination? pagination = null)
    {
        this.Code = statusCode;
        this.Message = message == string.Empty ? "Success" : message;
        this.Payload = payload;
        this.SentDate = sentDate;
        this.Pagination = pagination;
    }

    public AutoWrapper(DateTime sentDate,
                               object? payload = null,
                               Pagination? pagination = null)
    {
        this.Code = 200;
        this.Message = "Success";
        this.Payload = payload;
        this.SentDate = sentDate;
        this.Pagination = pagination;
    }

    public AutoWrapper(object? payload)
    {
        this.Code = 200;
        this.Payload = payload;
        this.Message = default;
    }

}

public class Pagination
{
    public int TotalItemsCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}

//Error Custom Class for AutoWrapper
public class responseException
{
    public string message { get; set; }    //Exception.Message
    public string trace { get; set; }     //Stack trace for error
    public string error_display { get; set; }     // Userfriendly Error for Display



    public responseException(string exceptionMessage, string stackTrace, string message)
    {
        this.message = message;
        this.trace = stackTrace;
        this.error_display = exceptionMessage;

    }

}
#region Functions
public static class AutoWrapperHelper
{
    public static ApiException GenerateError(Exception ex, string? message = default)
    {
        var validationException = ValidationExceptions.GetValidationException(ex.Message);
        if (validationException is not null)
            return validationException;
        if (ex is QException qException)
        {
            if (qException.CustomError is not null)
            {
                Log.Error("Message: {Message}\nCustomError: {CustomError}\nStackTrace: {StackTrace}", qException.Message, qException.CustomError, qException.StackTrace);
                return new ApiException(qException.CustomError);
            }
            else if (qException.Errors is not null && qException.Errors.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine("[");
                foreach (var _ in qException.Errors)
                {
                    sb.AppendLine($"Name:\"{_.Name}\",");
                    sb.AppendLine($"Reason:\"{_.Reason}\",");
                    sb.AppendLine();
                }
                sb.AppendLine("]");
                Log.Error("Message: {Message}\nValidationErrors: {sb}", "Request responded with one or more validation errors.", sb);
                return new ApiException(qException.Errors);
            }

            Log.Error("Message: {Message}\nStackTrace: {StackTrace}", ex.Message, ex.StackTrace);
            return new ApiException(ex);
        }
        else
        {
            Log.Error("Message: {Message}\nStackTrace: {StackTrace}", ex.Message, ex.StackTrace);

            return new ApiException(
                      ex
                      );
        }

    }
}
#endregion
