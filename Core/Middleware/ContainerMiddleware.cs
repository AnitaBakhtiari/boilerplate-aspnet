using Core.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Middleware;

public class ContainerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public ContainerMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public Task Invoke(HttpContext httpContext)
    {
        //AutoFac
        //var scope = ConfigureConfig.Configure().BeginLifetimeScope();
        //ServicesCall.Container = scope;

        //Service Provider
        var scope = _serviceProvider.CreateScope();
        ServicesCall.Configure(scope);

        _next(httpContext);

        //scope.Dispose();

       return Task.CompletedTask;
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ContainerMiddleware>();
    }
}