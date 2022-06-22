using Bread.Attribute;
using Bread.MinimalApi;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Bread.Middleware;

public static class MapInstantApIsMiddlewareExtension
{
    public static IEndpointRouteBuilder UseMapInstantApIs<T>(this IEndpointRouteBuilder app, IEnumerable<Type> allTypes)
        where T : DbContext
    {
        //var allTypes = Assembly.GetExecutingAssembly().GetTypes()
        //    .Where(t => t.CustomAttributes.Any(c => c.AttributeType == typeof(BreadAttribute)));

        foreach (var type in allTypes)
        {
            var attribute = type.GetCustomAttributes(typeof(BreadAttribute), false).FirstOrDefault();

            if (attribute is null) continue;

            app.MapInstantApIs<T>(config =>
            {
                config.IncludeTable(type.Name + "s",
                    ((BreadAttribute) attribute).Methods,
                    ((BreadAttribute) attribute).Roles,
                    ((BreadAttribute) attribute).Path);
            });
        }

        return app;
    }
}