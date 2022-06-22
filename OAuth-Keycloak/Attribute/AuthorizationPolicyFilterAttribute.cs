using Core.Message;
using Core.Metadata;
using Http.Exception;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Extensions;
using OAuth_Keycloak.RequestModels;
using OAuth_Keycloak.Services;

namespace OAuth_Keycloak.Attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizationPolicyFilterAttribute : System.Attribute, IAsyncActionFilter
{
    private const string Permission = "permission";
    private const string AccessToken = "access_token";

    public AuthorizationPolicyFilterAttribute()
    {
    }

    public AuthorizationPolicyFilterAttribute(MethodEnum scope)
    {
        Scope = scope;
    }

    public MethodEnum Scope { get; set; }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var keycloakService = context.HttpContext.RequestServices.GetService<IKeycloakService>();
        var accessToken = await context.HttpContext.GetTokenAsync(AccessToken);
        var path = context.HttpContext.Request.Path;
        var scope = Scope.GetDisplayName() ?? context.HttpContext.Request.Method;

        var resourceIds = keycloakService?.GetResourceIdsAsync(new GetResourceIdsRequestModel
        {
            Path = path,
            Token = accessToken!
        });

        if (resourceIds == null)
            throw new NotFoundException(ResponseExceptionType.RecourseIdsNotFound);


        if (!resourceIds.Result.IsSuccess)
            throw new UnauthorizedException(ResponseExceptionType.InvalidBearerToken);

        var list = new List<KeyValuePair<string, string>>();

        list.AddRange(resourceIds?.Result.ResourceIds.Select(resourceId =>
            new KeyValuePair<string, string>(Permission, $"{resourceId}#{scope}"))!);

        var validateAccess = keycloakService?.ValidateAccessTokenAsync(new ValidateAccessTokenRequestModel
        {
            Token = accessToken!,
            BodyList = list
        });

        if (validateAccess == null || !validateAccess.Result.IsSuccess)
            throw new UnauthorizedException(ResponseExceptionType.KeycloakValidateAccessTokenFailed);

        await next();
    }
}