using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Util.Extension;

public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperService(this IServiceCollection services, string myAssembly)
    {
        var mappingConfig = new MapperConfiguration(mc => { mc.AddMaps(myAssembly); });

        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}