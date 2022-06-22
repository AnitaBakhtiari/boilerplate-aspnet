using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class PreConditionRequiredException : HttpException
{
    public PreConditionRequiredException(LocalizedString errorMessage) : base(HttpStatusCode.PreconditionRequired,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public PreConditionRequiredException(string errorMessage) : base(HttpStatusCode.PreconditionRequired,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public PreConditionRequiredException(ResponseExceptionType errorType) : base(HttpStatusCode.PreconditionRequired,
        errorType)
    {
    }
}