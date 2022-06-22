using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class BandwidthLimitExceededException : HttpException
{
    //todo
    public BandwidthLimitExceededException(LocalizedString errorMessage) : base(HttpStatusCode.BadRequest,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public BandwidthLimitExceededException(string errorMessage) : base(HttpStatusCode.BadRequest,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public BandwidthLimitExceededException(ResponseExceptionType errorType) : base(HttpStatusCode.BadRequest, errorType)
    {
    }
}