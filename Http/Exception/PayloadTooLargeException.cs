using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class PayloadTooLargeException : HttpException
{
    //todo
    public PayloadTooLargeException(LocalizedString errorMessage) : base(HttpStatusCode.BadRequest,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public PayloadTooLargeException(string errorMessage) : base(HttpStatusCode.BadRequest,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public PayloadTooLargeException(ResponseExceptionType errorType) : base(HttpStatusCode.BadRequest, errorType)
    {
    }
}