using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class RequestTimeoutException : HttpException
{
    public RequestTimeoutException(LocalizedString errorMessage) : base(HttpStatusCode.RequestTimeout,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public RequestTimeoutException(string errorMessage) : base(HttpStatusCode.RequestTimeout,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public RequestTimeoutException(ResponseExceptionType errorType) : base(HttpStatusCode.RequestTimeout, errorType)
    {
    }
}