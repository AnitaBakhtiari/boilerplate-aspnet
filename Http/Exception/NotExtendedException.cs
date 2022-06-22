using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class NotExtendedException : HttpException
{
    public NotExtendedException(LocalizedString errorMessage) : base(HttpStatusCode.NotExtended,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotExtendedException(string errorMessage) : base(HttpStatusCode.NotExtended,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NotExtendedException(ResponseExceptionType errorType) : base(HttpStatusCode.NotExtended, errorType)
    {
    }
}