using Microsoft.AspNetCore.Builder;

namespace Http.Middleware.Extensions;

public static class LocalizationMiddlewareExtension
{
    public static IApplicationBuilder UseCustomRequestLocalization(this IApplicationBuilder app)
    {
        var supportedCultures = new[] {"en-US", "fa"};
        var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

        app.UseRequestLocalization(localizationOptions);

        return app;
    }
}