using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class BadRequestException : HttpException
{
    public BadRequestException(LocalizedString errorMessage) : base(HttpStatusCode.BadRequest,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public BadRequestException(string errorMessage) : base(HttpStatusCode.BadRequest,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public BadRequestException(ResponseExceptionType errorType) : base(HttpStatusCode.BadRequest, errorType)
    {
    }
}