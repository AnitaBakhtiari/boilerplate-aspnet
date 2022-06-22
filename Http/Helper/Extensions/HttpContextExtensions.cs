using System.Net;
using Microsoft.AspNetCore.Http;

namespace Http.Helper.Extensions;

public static class HttpContextExtensions
{
    public static IPAddress GetRemoteIpAddress(this HttpContext context, bool allowForwarded = true)
    {
        if (!allowForwarded) return context.Connection.RemoteIpAddress!;
        var header = context.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ??
                     context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        return (IPAddress.TryParse(header, out var ip) ? ip : context.Connection.RemoteIpAddress)!;
    }
}