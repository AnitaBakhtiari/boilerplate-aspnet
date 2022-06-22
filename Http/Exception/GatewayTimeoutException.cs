using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class GatewayTimeoutException : HttpException
{
    public GatewayTimeoutException(LocalizedString errorMessage) : base(HttpStatusCode.GatewayTimeout,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public GatewayTimeoutException(string errorMessage) : base(HttpStatusCode.GatewayTimeout,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public GatewayTimeoutException(ResponseExceptionType errorType) : base(HttpStatusCode.GatewayTimeout, errorType)
    {
    }
}