using Bread.MinimalApi;
using Cache.Extension;
using Cache.Interceptor;
using Castle.DynamicProxy;
using Context.Actions.Interfaces;
using Core;
using DataCore.Tasks.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OAuth_Keycloak;
using OAuth_Keycloak.Services;
using Test.Actions;
using Test.Context;
using Test.Payload;
using Test.Repository;
using Test.Tasks;
using Util.Mapper;
using Util.Paging;

namespace Test;

public static class DependencyContainer
{
    public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "CustomAttribute", Version = "v1"});
        });
        services.AddHttpContextAccessor();
        services.AddHttpClient();

        services.AddSqlite<MyContext>("Data Source=context/contacts.db");
        services.AddDbContext<MyContext>();
        services.AddLocalization(opt => opt.ResourcesPath = "Resources");

        services.AddInstantAPIs();
        
        services.AddJwt(configuration);
      
        services.AddEasyCaching(options =>
        {
            options.UseInMemory(configuration, "default", "EasyCaching:InMemory");
            //options.UseRedis(configuration, "Redis");
        });

        services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddSingleton(new ProxyGenerator());

        services.AddScoped<IKeycloakService, KeycloakService>();

        services.AddScoped<IInterceptor, CacheInterceptor>();

        services.AddProxiedScoped(typeof(IAction1<ContactResponse, int>), typeof(BrowseContactAction));

        services.AddScoped(typeof(IRepositoryTask1<IContactRepository, ContactResponse, int>),
            typeof(BrowseContactTask));


        services.AddScoped(typeof(IAction2<Task<Page<ContactResponse>>, int, int>), typeof(GetAllContactAsyncAction));
        services.AddScoped(typeof(IRepositoryTask2<IContactRepository, Task<Page<ContactResponse>>, int, int>),
            typeof(GetAllContactAsyncTask));


        services.AddScoped<BrowseContactTask>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();


        services.AddScoped<GetAllContactAsyncAction>();
        services.AddScoped<GetAllContactAsyncTask>();

        services.Configure<KeycloakOption>(configuration.GetSection("Authentication"));
    }
}