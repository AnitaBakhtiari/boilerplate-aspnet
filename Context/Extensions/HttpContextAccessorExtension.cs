using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace Context.Extensions;

public static class HttpContextAccessorExtension
{
    public static string GetUserId(this IHttpContextAccessor accessor)
    {
        var context = accessor.HttpContext!.Request.Headers["Authorization"].ToString();
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(context.Replace("Bearer ", "")) as JwtSecurityToken;
        return token?.Claims.FirstOrDefault(claim => claim.Type == "sub")!.Value!;
    }

    public static string GetUserName(this IHttpContextAccessor accessor)
    {
        return accessor.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value!;
    }

    public static string GetHierarchyId(this IHttpContextAccessor accessor)
    {
        var tokenContext = accessor.HttpContext!.Request.Headers["Authorization"].ToString();
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(tokenContext.Replace("Bearer ", "")) as JwtSecurityToken;
        return token?.Claims.FirstOrDefault(claim => claim.Type == "hierarchyId")!.Value!;
    }


    public static string GetTokenValue(this IHttpContextAccessor accessor, string value)
    {
        var tokenContext = accessor.HttpContext!.Request.Headers["Authorization"].ToString();
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(tokenContext.Replace("Bearer ", "")) as JwtSecurityToken;
        return token?.Claims.FirstOrDefault(claim => claim.Type == value)!.Value!;
    }
}