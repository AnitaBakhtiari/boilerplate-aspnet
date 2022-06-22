using System.Net;
using Core.Message;
using Http.Helper.Extensions;
using Microsoft.Extensions.Localization;

namespace Http.Exception;

public class InsufficientStorageException : HttpException
{
    public InsufficientStorageException(LocalizedString errorMessage) : base(HttpStatusCode.InsufficientStorage,
        errorMessage.Name.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public InsufficientStorageException(string errorMessage) : base(HttpStatusCode.InsufficientStorage,
        errorMessage.ToEnum<ResponseExceptionType>(), errorMessage)
    {
    }

    public InsufficientStorageException(ResponseExceptionType errorType) : base(HttpStatusCode.InsufficientStorage,
        errorType)
    {
    }
}