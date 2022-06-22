using System.Reflection;
using System.Text;
using Cache.Extension;
using Castle.DynamicProxy;
using EasyCaching.Core;
using Newtonsoft.Json;

namespace Cache.Interceptor;

public class CacheInterceptor : IInterceptor
{
    private readonly IEasyCachingProvider _cache;
    private string _cacheKey = null!;

    public CacheInterceptor(IEasyCachingProvider cache)
    {
        _cache = cache;
    }

    public void Intercept(IInvocation invocation)
    {
        if (invocation.MethodInvocationTarget.GetCustomAttributes(typeof(Attribute.Cache), false).FirstOrDefault()
            is Attribute.Cache cacheAttribute)
        {
            var serviceMethod = invocation.MethodInvocationTarget ?? invocation.Method;

            var cacheKeyParams = cacheAttribute.Key;

            var builder = new StringBuilder();
            var methodInfo = builder.Append($"{serviceMethod.ReflectedType.Name}-{serviceMethod.Name}");

            if (string.IsNullOrEmpty(cacheKeyParams))
            {
                _cacheKey = GetCacheKey(methodInfo.ToString(), invocation.Arguments);
            }
            else if (!cacheKeyParams.Contains("#"))
            {
                _cacheKey = builder.Append($"--{cacheKeyParams}").ToString();
            }
            else
            {
                var keys = cacheKeyParams.Split(",").Select(a => a.Replace("#", string.Empty));

                for (var i = 0; i < invocation.Arguments.Length; i++)
                    foreach (var key in keys)
                    {
                        var paramName = GetParamName(serviceMethod, i);

                        if (key.Equals(paramName, StringComparison.OrdinalIgnoreCase))
                        {
                            var value = invocation.Arguments[i];
                            builder.Append($"--{key}:{value}");
                        }
                        else if (key.Contains(paramName, StringComparison.OrdinalIgnoreCase))
                        {
                            var absoluteKey = key.ReplaceFirst($"{paramName}.", "").FirstCharToUpper();
                            if (string.IsNullOrEmpty(absoluteKey)) continue;

                            foreach (var arg in invocation.Arguments[i].GetType().GetProperties())
                            {
                                if (!absoluteKey.Equals(arg.Name)) continue;
                                var absoluteValue = (int) arg.GetValue(invocation.Arguments[i], null)!;

                                builder.Append($"--{absoluteKey}:{absoluteValue}");
                            }
                        }
                    }

                _cacheKey = builder.ToString();
            }

            if (_cache.Exists(_cacheKey))
            {
                //invocation.ReturnValue = _cache.Get<byte[]>(_cacheKey).Value.ByteArrayToObject();
                invocation.ReturnValue =
                    JsonConvert.DeserializeObject(_cache.Get<string>(_cacheKey).Value, invocation.Method.ReturnType);
            }
            else
            {
                invocation.Proceed();
                _cache.Set(_cacheKey, JsonConvert.SerializeObject(invocation.ReturnValue),
                    TimeSpan.FromSeconds(cacheAttribute.Seconds));
            }
        }
        else
        {
            invocation.Proceed();
        }
    }

    private static string GetParamName(MethodBase method, int index)
    {
        var retVal = string.Empty;

        if (method.GetParameters().Length > index)
            retVal = method.GetParameters()[index].Name;

        return retVal!;
    }

    private static string GetCacheKey(string method, IEnumerable<object> arguments)
    {
        return $"{method}--{string.Join("--", arguments.Select(x => x.ToString()))}";
    }
}