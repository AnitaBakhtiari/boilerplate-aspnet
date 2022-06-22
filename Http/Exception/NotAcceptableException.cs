using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class NotAcceptableException : HttpException
{
    public NotAcceptableException(LocalizedString errorMessage) : base(HttpStatusCode.NotAcceptable,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotAcceptableException(string errorMessage) : base(HttpStatusCode.NotAcceptable,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotAcceptableException(ResponseExceptionType errorType) : base(HttpStatusCode.NotAcceptable, errorType)
    {
    }
}