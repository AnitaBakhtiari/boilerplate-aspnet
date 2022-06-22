using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bread.MinimalApi;

internal class MapApiExtensions
{
    private static readonly Dictionary<Type, PropertyInfo> IdLookup = new();

    private static ILogger _logger;

    internal static void Initialize<TD, TC>(ILogger logger)
        where TD : DbContext
        where TC : class
    {
        _logger = logger;

        var theType = typeof(TC);
        var idProp = theType.GetProperty("id", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ??
                     theType.GetProperties().FirstOrDefault(p =>
                         p.CustomAttributes.Any(a => a.AttributeType == typeof(KeyAttribute)));

        if (idProp != null) IdLookup.Add(theType, idProp);
    }

    [ApiMethod(ApiMethodsToGenerate.Get)]
    internal static void MapInstantGetAll<TD, TC>(IEndpointRouteBuilder app, string url, Roles roles)
        where TD : DbContext where TC : class
    {
        IAuthorizeData authorize = new AuthorizeData
        {
            Roles = roles.ToString()
        };

        _logger.LogInformation($"Created API: HTTP GET\t{url}");
        app.MapGet(url, ([FromServices] TD db) => Results.Ok(db.Set<TC>())).RequireAuthorization(authorize);
    }

    [ApiMethod(ApiMethodsToGenerate.GetById)]
    internal static void MapGetById<TD, TC>(IEndpointRouteBuilder app, string url, Roles roles)
        where TD : DbContext where TC : class
    {
        // identify the ID field
        var theType = typeof(TC);
        var idProp = IdLookup[theType];

        if (idProp == null) return;

        _logger.LogInformation($"Created API: HTTP GET\t{url}/{{id}}");

        IAuthorizeData authorize = new AuthorizeData
        {
            Roles = roles.ToString()
        };

        app.MapGet($"{url}/{{id}}", async ([FromServices] TD db, [FromRoute] string id) =>
        {
            var outValue = default(TC);
            if (idProp.PropertyType == typeof(Guid))
                outValue = await db.Set<TC>().FindAsync(Guid.Parse(id));
            else if (idProp.PropertyType == typeof(int))
                outValue = await db.Set<TC>().FindAsync(int.Parse(id));
            else if (idProp.PropertyType == typeof(long))
                outValue = await db.Set<TC>().FindAsync(long.Parse(id));
            else //if (idProp.PropertyType == typeof(string))
                outValue = await db.Set<TC>().FindAsync(id);

            return outValue is null ? Results.NotFound() : Results.Ok(outValue);
        }).RequireAuthorization(authorize);
        ;
    }

    [ApiMethod(ApiMethodsToGenerate.Insert)]
    internal static void MapInstantPost<D, C>(IEndpointRouteBuilder app, string url, Roles roles)
        where D : DbContext where C : class
    {
        _logger.LogInformation($"Created API: HTTP POST\t{url}");
        IAuthorizeData authorize = new AuthorizeData
        {
            Roles = roles.ToString()
        };

        app.MapPost(url, async ([FromServices] D db, [FromBody] C newObj) =>
        {
            db.Add(newObj);
            await db.SaveChangesAsync();
            var id = IdLookup[typeof(C)].GetValue(newObj);
            return Results.Created($"{url}/{id!}", newObj);
        }).RequireAuthorization(authorize);
        ;
    }

    [ApiMethod(ApiMethodsToGenerate.Update)]
    internal static void MapInstantPut<D, C>(IEndpointRouteBuilder app, string url, Roles roles)
        where D : DbContext where C : class
    {
        _logger.LogInformation($"Created API: HTTP PUT\t{url}");

        IAuthorizeData authorize = new AuthorizeData
        {
            Roles = roles.ToString()
        };

        app.MapPut($"{url}/{{id}}", async ([FromServices] D db, [FromRoute] string id, [FromBody] C newObj) =>
        {
            db.Set<C>().Attach(newObj);
            db.Entry(newObj).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Results.NoContent();
        }).RequireAuthorization(authorize);
        ;
    }

    [ApiMethod(ApiMethodsToGenerate.Delete)]
    internal static void MapDeleteById<D, C>(IEndpointRouteBuilder app, string url, Roles roles)
        where D : DbContext where C : class
    {
        // identify the ID field
        var theType = typeof(C);
        var idProp = IdLookup[theType];

        if (idProp == null) return;
        _logger.LogInformation($"Created API: HTTP DELETE\t{url}");

        IAuthorizeData authorize = new AuthorizeData
        {
            Roles = roles.ToString()
        };


        app.MapDelete($"{url}/{{id}}", async ([FromServices] D db, [FromRoute] string id) =>
        {
            var set = db.Set<C>();
            C? obj;

            if (idProp.PropertyType == typeof(Guid))
                obj = await set.FindAsync(Guid.Parse(id));
            else if (idProp.PropertyType == typeof(int))
                obj = await set.FindAsync(int.Parse(id));
            else if (idProp.PropertyType == typeof(long))
                obj = await set.FindAsync(long.Parse(id));
            else //if (idProp.PropertyType == typeof(string))
                obj = await set.FindAsync(id);

            if (obj == null) return Results.NotFound();

            db.Set<C>().Remove(obj);
            await db.SaveChangesAsync();
            return Results.NoContent();
        }).RequireAuthorization(authorize);
        ;
    }
}