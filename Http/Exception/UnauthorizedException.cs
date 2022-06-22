using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class UnauthorizedException : HttpException
{
    public UnauthorizedException(LocalizedString errorMessage) : base(HttpStatusCode.Unauthorized,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public UnauthorizedException(string errorMessage) : base(HttpStatusCode.Unauthorized,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public UnauthorizedException(ResponseExceptionType errorType) : base(HttpStatusCode.Unauthorized, errorType)
    {
    }
}