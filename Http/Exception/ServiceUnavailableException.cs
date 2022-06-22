using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class ServiceUnavailableException : HttpException
{
    public ServiceUnavailableException(LocalizedString errorMessage) : base(HttpStatusCode.ServiceUnavailable,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ServiceUnavailableException(string errorMessage) : base(HttpStatusCode.ServiceUnavailable,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ServiceUnavailableException(ResponseExceptionType errorType) : base(HttpStatusCode.ServiceUnavailable,
        errorType)
    {
    }
}