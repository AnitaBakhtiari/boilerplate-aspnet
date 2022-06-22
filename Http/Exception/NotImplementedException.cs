using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class NotImplementedException : HttpException
{
    public NotImplementedException(LocalizedString errorMessage) : base(HttpStatusCode.NotImplemented,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotImplementedException(string errorMessage) : base(HttpStatusCode.NotImplemented,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotImplementedException(ResponseExceptionType errorType) : base(HttpStatusCode.NotImplemented, errorType)
    {
    }
}