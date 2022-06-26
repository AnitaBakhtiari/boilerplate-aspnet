namespace Core.Provider;

public static partial class ServicesCall
{
    public static  Task<TOutput> CallAsync<TService, TOutput>()
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, null) is not Task<TOutput> result)
            throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static Task<TOutput> CallAsync<TService, TOutput, TIn>(TIn param)
    {
        var service = GetService(typeof(TService));

        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return  Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2>(TIn1 param1, TIn2 param2)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);     
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3>(TIn1 param1, TIn2 param2,
        TIn3 param3)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4>(TIn1 param1, TIn2 param2,
        TIn3 param3,
        TIn4 param4)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5>(TIn1 param1,
        TIn2 param2,
        TIn3 param3, TIn4 param4, TIn5 param5)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!, param5!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(TIn1 param1,
        TIn2 param2,
        TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!, param5!, param6!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(
        TIn1 param1, TIn2 param2,
        TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!, param5!, param6!, param7!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(
        TIn1 param1,
        TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7, TIn8 param8)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!, param5!, param6!, param7!, param8!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput>
        CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(TIn1 param1,
            TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7, TIn8 param8, TIn9 param9)
    {
        var service = GetService(typeof(TService));
        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!, param5!, param6!, param7!, param8!, param9!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }

    public static  Task<TOutput> CallAsync<TService, TOutput, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9,
        TIn10>(
        TIn1 param1, TIn2 param2, TIn3 param3, TIn4 param4, TIn5 param5, TIn6 param6, TIn7 param7, TIn8 param8,
        TIn9 param9, TIn10 param10)
    {
        var service = GetService(typeof(TService));

        if (service.GetType().GetMethod(Execute)?.Invoke(service, new object[]
            {
                param1!, param2!, param3!, param4!, param5!, param6!, param7!, param8!, param9!, param10!
            }) is not Task<TOutput> result) throw new InvalidOperationException();

        return Task.FromResult(result.Result);
    }
}