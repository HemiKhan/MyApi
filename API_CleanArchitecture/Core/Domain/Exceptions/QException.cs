namespace Domain.Exceptions;

using System;
using System.Collections.Generic;

using AutoWrapper.Wrappers;

public class QException : ApiException
{
    public QException(IEnumerable<ValidationError> errors, int statusCode = 400) : base(errors, statusCode)
    {
    }

    public QException(object customError, int statusCode = 400) : base(customError, statusCode)
    {
    }

    public QException(Exception ex, int statusCode = 500) : base(ex, statusCode)
    {
    }

    public QException(string message, int statusCode = 400, string? errorCode = null, string? refLink = null) : base(message, statusCode, errorCode, refLink)
    {
    }
}
