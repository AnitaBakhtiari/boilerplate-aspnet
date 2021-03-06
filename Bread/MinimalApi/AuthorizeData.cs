using Microsoft.AspNetCore.Authorization;

namespace Bread.MinimalApi;

internal class AuthorizeData : IAuthorizeData
{
    public string? Policy { get; set; }
    public string? Roles { get; set; }
    public string? AuthenticationSchemes { get; set; }
}