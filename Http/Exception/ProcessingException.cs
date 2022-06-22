using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class ProcessingException : HttpException
{
    public ProcessingException(LocalizedString errorMessage) : base(HttpStatusCode.Processing,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ProcessingException(string errorMessage) : base(HttpStatusCode.Processing,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ProcessingException(ResponseExceptionType errorType) : base(HttpStatusCode.Processing, errorType)
    {
    }
}