using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class ProxyAuthenticationRequired : HttpException
{
    public ProxyAuthenticationRequired(LocalizedString errorMessage) : base(HttpStatusCode.ProxyAuthenticationRequired,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ProxyAuthenticationRequired(string errorMessage) : base(HttpStatusCode.ProxyAuthenticationRequired,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public ProxyAuthenticationRequired(ResponseExceptionType errorType) : base(
        HttpStatusCode.ProxyAuthenticationRequired, errorType)
    {
    }
}