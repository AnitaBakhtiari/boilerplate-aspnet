using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class ToManyRequestsException : HttpException
{
    public ToManyRequestsException(LocalizedString errorMessage) : base(HttpStatusCode.TooManyRequests,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ToManyRequestsException(string errorMessage) : base(HttpStatusCode.TooManyRequests,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ToManyRequestsException(ResponseExceptionType errorType) : base(HttpStatusCode.TooManyRequests, errorType)
    {
    }
}