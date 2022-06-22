using System.Text;
using Http.Exception;
using Http.Middleware.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Http.Middleware.Extensions;

public static class ExceptionHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler =>
        {
            handler.Run(async context =>
            {
                try
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature is {Error: HttpException exceptionContext})
                    {
                        context.Response.StatusCode = (int) exceptionContext.HttpStatusCode;
                        context.Response.ContentType = "application/json";

                        var jsonString = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(
                            new ApiResponse<object>
                            {
                                errorMessage = exceptionContext.Message,
                                errorCode = exceptionContext.ErrorCode,
                                dateNow = DateTime.Now,
                                path = exceptionHandlerPathFeature.Path
                            }));

                        await context.Response.Body.WriteAsync(jsonString, 0, jsonString.Length);
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        if (exceptionHandlerPathFeature != null)
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse<object>
                            {
                                errorMessage = "unhandled exception",
                                data = exceptionHandlerPathFeature.Error,
                                errorCode = 500
                            }));
                    }
                }
                catch (System.Exception)
                {
                    // ignored
                }
            });
        });
        return app;
    }
}