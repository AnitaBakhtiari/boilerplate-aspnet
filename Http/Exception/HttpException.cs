using System.Net;
using Core.Message;
using Core.Message.ResponseMessage;
using Core.Payload;
using Core.Provider;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class HttpException : System.Exception, IPayload
{
    public HttpException(HttpStatusCode httpStatusCode, ResponseExceptionType errorType, LocalizedString message)
    {
        Message = message;
        HttpStatusCode = httpStatusCode;
        ErrorCode = (int) errorType;
    }

    public HttpException(HttpStatusCode httpStatusCode, ResponseExceptionType errorType, string message)
    {
        var localize = ServicesCall.GetService<IStringLocalizer<ErrorMessage>>();
        Message = localize[message].ToString();
        HttpStatusCode = httpStatusCode;
        ErrorCode = (int) errorType;
    }

    public HttpException(HttpStatusCode httpStatusCode, ResponseExceptionType errorType)
    {
        Message = ServicesCall.GetService<IStringLocalizer<ErrorMessage>>()[errorType.ToString()].ToString();
        HttpStatusCode = httpStatusCode;
        ErrorCode = (int) errorType;
    }


    public override string Message { get; } = null!;
    public int ErrorCode { get; }
    public HttpStatusCode HttpStatusCode { get; }
}