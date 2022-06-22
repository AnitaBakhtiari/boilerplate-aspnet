using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class ConflictException : HttpException
{
    public ConflictException(LocalizedString errorMessage) : base(HttpStatusCode.Conflict,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ConflictException(string errorMessage) : base(HttpStatusCode.Conflict,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ConflictException(ResponseExceptionType errorType) : base(HttpStatusCode.Conflict, errorType)
    {
    }
}