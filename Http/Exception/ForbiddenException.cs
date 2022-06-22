using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class ForbiddenException : HttpException
{
    public ForbiddenException(LocalizedString errorMessage) : base(HttpStatusCode.Forbidden,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ForbiddenException(string errorMessage) : base(HttpStatusCode.Forbidden,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ForbiddenException(ResponseExceptionType errorType) : base(HttpStatusCode.Forbidden, errorType)
    {
    }
}