using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Bread.MinimalApi;

public static class WebApplicationExtensions
{
    internal const string LoggerCategoryName = "InstantAPI";
    private static InstantApIsConfig Configuration { get; set; } = new();

    public static IEndpointRouteBuilder MapInstantApIs<TD>(this IEndpointRouteBuilder app,
        Action<InstantApIsConfigBuilder<TD>> options = null!) where TD : DbContext
    {
        if (app is IApplicationBuilder applicationBuilder) AddOpenApiConfiguration(app, options, applicationBuilder);

        // Get the tables on the DbContext
        var dbTables = GetDbTablesForContext<TD>();

        var requestedTables = !Configuration.Tables.Any()
            ? dbTables
            : Configuration.Tables
                .Where(t => dbTables.Any(db => db.Name.Equals(t.Name, StringComparison.OrdinalIgnoreCase))).ToArray();

        MapInstantApIsUsingReflection<TD>(app, requestedTables);

        return app;
    }

    private static void MapInstantApIsUsingReflection<TD>(IEndpointRouteBuilder app,
        IEnumerable<TypeTable> requestedTables) where TD : DbContext
    {
        ILogger logger = NullLogger.Instance;
        if (app.ServiceProvider != null)
        {
            var loggerFactory = app.ServiceProvider.GetRequiredService<ILoggerFactory>();
            logger = loggerFactory.CreateLogger(LoggerCategoryName);
        }

        var allMethods = typeof(MapApiExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Where(m => m.Name.StartsWith("Map")).ToArray();
        var initialize = typeof(MapApiExtensions).GetMethod("Initialize", BindingFlags.NonPublic | BindingFlags.Static);
        foreach (var table in requestedTables)
        {
            // The default URL for an InstantAPI is /api/TABLENAME
            //var url = $"/api/{table.Name}";

            initialize!.MakeGenericMethod(typeof(TD), table.InstanceType).Invoke(null, new[] {logger});

            // The remaining private static methods in this class build out the Mapped API methods..
            // let's use some reflection to get them
            foreach (var method in allMethods)
            {
                var sigAttr = method.CustomAttributes.First(x => x.AttributeType == typeof(ApiMethodAttribute))
                    .ConstructorArguments.First();
                var methodType = (ApiMethodsToGenerate) sigAttr.Value!;
                if ((table.ApiMethodsToGenerate & methodType) != methodType) continue;

                var genericMethod = method.MakeGenericMethod(typeof(TD), table.InstanceType);
                genericMethod.Invoke(null, new object[] {app, table.BaseUrl.ToString(), table.Roles});
            }
        }
    }

    private static void AddOpenApiConfiguration<TD>(IEndpointRouteBuilder app,
        Action<InstantApIsConfigBuilder<TD>> options, IApplicationBuilder applicationBuilder) where TD : DbContext
    {
        // Check if AddInstantAPIs was called by getting the service options and evaluate EnableSwagger property
        var serviceOptions = applicationBuilder.ApplicationServices
            .GetRequiredService<IOptions<InstantAPIsServiceOptions>>().Value;
        if (serviceOptions?.EnableSwagger == null)
            throw new ArgumentException("Call builder.Services.AddInstantAPIs(options) before MapInstantAPIs.");

        var webApp = (WebApplication) app;
        if (serviceOptions.EnableSwagger == EnableSwagger.Always ||
            serviceOptions.EnableSwagger == EnableSwagger.DevelopmentOnly && webApp.Environment.IsDevelopment())
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI();
        }

        var ctx = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService(typeof(TD)) as TD;
        var builder = new InstantApIsConfigBuilder<TD>(ctx);
        if (options == null) return;
        options(builder);
        Configuration = builder.Build();
    }

    internal static IEnumerable<TypeTable> GetDbTablesForContext<TD>() where TD : DbContext
    {
        return typeof(TD).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.PropertyType.FullName!.StartsWith("Microsoft.EntityFrameworkCore.DbSet"))
            .Select(x => new TypeTable
            {
                Name = x.Name,
                InstanceType = x.PropertyType.GenericTypeArguments.First(),
                BaseUrl = new Uri($"/api/{x.Name}", UriKind.RelativeOrAbsolute)
            })
            .ToArray();
    }

    internal class TypeTable
    {
        public string Name { get; set; } = null!;
        public Type InstanceType { get; set; } = null!;
        public ApiMethodsToGenerate ApiMethodsToGenerate { get; set; } = ApiMethodsToGenerate.All;
        public Roles Roles { get; set; } = Roles.administrators1;
        public Uri BaseUrl { get; set; } = null!;
    }
}