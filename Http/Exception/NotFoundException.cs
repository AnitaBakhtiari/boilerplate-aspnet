using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class NotFoundException : HttpException
{
    public NotFoundException(LocalizedString errorMessage) : base(HttpStatusCode.NotFound,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotFoundException(string errorMessage) : base(HttpStatusCode.NotFound,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotFoundException(ResponseExceptionType errorType) : base(HttpStatusCode.NotFound, errorType)
    {
    }
}