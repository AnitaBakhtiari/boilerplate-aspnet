using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class UpgradeRequiredException : HttpException
{
    public UpgradeRequiredException(LocalizedString errorMessage) : base(HttpStatusCode.UpgradeRequired,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public UpgradeRequiredException(string errorMessage) : base(HttpStatusCode.UpgradeRequired,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public UpgradeRequiredException(ResponseExceptionType errorType) : base(HttpStatusCode.UpgradeRequired, errorType)
    {
    }
}