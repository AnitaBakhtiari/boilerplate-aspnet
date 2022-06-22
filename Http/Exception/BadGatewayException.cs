using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class BadGatewayException : HttpException
{
    public BadGatewayException(LocalizedString errorMessage) : base(HttpStatusCode.BadGateway,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public BadGatewayException(string errorMessage) : base(HttpStatusCode.BadGateway,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public BadGatewayException(ResponseExceptionType errorType) : base(HttpStatusCode.BadGateway, errorType)
    {
    }
}