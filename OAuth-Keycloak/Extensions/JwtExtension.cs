using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core;

public static class JwtExtension
{
    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = bool.Parse(configuration["Authentication:RequireHttpsMetadata"]);
                options.Authority = configuration["Authentication:Authority"];
                options.IncludeErrorDetails = bool.Parse(configuration["Authentication:IncludeErrorDetails"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = bool.Parse(configuration["Authentication:ValidateAudience"]),
                    ValidAudience = configuration["Authentication:ValidAudience"],
                    ValidateIssuerSigningKey = bool.Parse(configuration["Authentication:ValidateIssuerSigningKey"]),
                    ValidateIssuer = bool.Parse(configuration["Authentication:ValidateIssuer"]),
                    ValidIssuer = configuration["Authentication:ValidIssuer"],
                    ValidateLifetime = bool.Parse(configuration["Authentication:ValidateLifetime"])
                };
                options.SaveToken = true;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = e =>
                    {
                        e.NoResult();
                        e.Response.StatusCode = StatusCodes.Status401Unauthorized;

                        return Task.CompletedTask;
                    }
                };
            });


        return services;
    }
}