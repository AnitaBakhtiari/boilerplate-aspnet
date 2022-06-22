using System.Reflection;
using Bread.Attribute;
using Bread.Middleware;
using Core.Middleware;
using Http.Middleware.Extensions;
using Test;
using Test.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomRequestLocalization();

// todo
var allTypes = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.CustomAttributes.Any(c => c.AttributeType == typeof(BreadAttribute)));

app.UseMapInstantApIs<MyContext>(allTypes);

app.UseMiddleware();

app.UseMiddleware<ContainerMiddleware>();


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCustomExceptionHandler();
app.MapControllers();
app.Run();