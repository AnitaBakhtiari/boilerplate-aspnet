using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class RollBackException : HttpException
{
    public RollBackException(LocalizedString errorMessage) : base(HttpStatusCode.Conflict,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public RollBackException(string errorMessage) : base(HttpStatusCode.Conflict,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public RollBackException(ResponseExceptionType errorType) : base(HttpStatusCode.Conflict, errorType)
    {
    }
}