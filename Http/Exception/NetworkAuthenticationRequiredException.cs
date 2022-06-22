using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class NetworkAuthenticationRequiredException : HttpException
{
    public NetworkAuthenticationRequiredException(LocalizedString errorMessage) : base(
        HttpStatusCode.NetworkAuthenticationRequired, errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NetworkAuthenticationRequiredException(string errorMessage) : base(
        HttpStatusCode.NetworkAuthenticationRequired, errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public NetworkAuthenticationRequiredException(ResponseExceptionType errorType) : base(
        HttpStatusCode.NetworkAuthenticationRequired, errorType)
    {
    }
}