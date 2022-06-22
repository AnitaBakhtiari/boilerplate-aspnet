using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class TokenException : HttpException
{
    public TokenException(LocalizedString errorMessage) : base(HttpStatusCode.Unauthorized,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public TokenException(string errorMessage) : base(HttpStatusCode.Unauthorized,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public TokenException(ResponseExceptionType errorType) : base(HttpStatusCode.Unauthorized, errorType)
    {
    }
}