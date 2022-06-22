using Microsoft.Extensions.DependencyInjection;

namespace Core.Provider;

public static partial class ServicesCall
{
    private const string Execute = "Execute";

    private static IServiceScope? _scope;
    //public static ILifetimeScope? Container;

    public static void Configure(IServiceScope serviceProvider)
    {
        _scope = serviceProvider;
    }

    public static object GetService(Type action)
    {
        //var service = Container!.Resolve(action);
        var services = _scope?.ServiceProvider.GetServices(action.IsInterface ? action : action.DumpInterface().First());
        var service = services.FirstOrDefault(a => a.GetType() == action);
        if (service == null) throw new InvalidOperationException();
        return service;
    }


    public static object GetServiceWithoutInterface(Type action)
    {
        var service = _scope?.ServiceProvider.GetService(action);
        if (service == null) throw new InvalidOperationException();
        return service;
    }


    public static T GetService<T>()
    {
        var service = _scope?.ServiceProvider.GetService(typeof(T));
        if (service == null) throw new InvalidOperationException();
        return (T)service;
    }

    public static TOutput Call<TService, TOutput>()
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, null);
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn>(TIn param)
    {
        var service = GetService(typeof(TService));

        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param!
        });

        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2>(TIn1 param1, TIn2 param2)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3>(TIn1 param1, TIn2 param2, TIn3 param3)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4>(TIn1 param1, TIn2 param2, TIn3 param3,
        TIn4 param4)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5>(TIn1 param1, TIn2 param2,
        TIn3 param3, TIn4 param4, TIn5 param5)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!, param5!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(TIn1 param1, TIn2 param2,
        TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!, param5!, param6!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(TIn1 param1, TIn2 param2,
        TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!, param5!, param6!, param7!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(TIn1 param1,
        TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7, TIn8 param8)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!, param5!, param6!, param7!, param8!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(TIn1 param1,
        TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7, TIn8 param8, TIn9 param9)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!, param5!, param6!, param7!, param8!, param9!
        });
        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }

    public static TOutput Call<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>(
        TIn1 param1, TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7, TIn8 param8,
        TIn9 param9, TIn10 param10)
    {
        var service = GetService(typeof(TService));
        var result = service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
        {
            param1!, param2!, param3!, param4!, param5!, param6!, param7!, param8!, param9!, param10!
        });

        if (result == null) throw new InvalidOperationException();

        return (TOutput)result;
    }
}