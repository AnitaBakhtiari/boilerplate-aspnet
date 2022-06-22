using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class UnSupportMediaTypeException : HttpException
{
    public UnSupportMediaTypeException(LocalizedString errorMessage) : base(HttpStatusCode.UnsupportedMediaType,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public UnSupportMediaTypeException(string errorMessage) : base(HttpStatusCode.UnsupportedMediaType,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public UnSupportMediaTypeException(ResponseExceptionType errorType) : base(HttpStatusCode.UnsupportedMediaType,
        errorType)
    {
    }
}