using Microsoft.Extensions.Caching.Memory;
using Optional;
using SpecialApp.Base;
using StructureMap.DynamicInterception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service.Proxy
{
    public class CachingInterceptor : ICachingInterceptor
    {
        private readonly IMemoryCache cache;
        private readonly IUserIdentity identity;
        private readonly IDictionary<string, Func<IAsyncMethodInvocation, Task<IMethodInvocationResult>>> CallWithOrWithoutCache
            = new Dictionary<string, Func<IAsyncMethodInvocation, Task<IMethodInvocationResult>>>();

        public CachingInterceptor(IMemoryCache cache, IUserIdentity identity)
        {
            this.cache = cache;
            this.identity = identity;

            this.CallWithOrWithoutCache.Add(true.ToString(), GetFromCache);
            this.CallWithOrWithoutCache.Add(false.ToString(), GetWithoutCache);
        }

        public async Task<IMethodInvocationResult> InterceptAsync(IAsyncMethodInvocation methodInvocation)
        {
            return await CallWithOrWithoutCache[IsValidMethodCall(methodInvocation).ToString()]
                .Invoke(methodInvocation);
        }

        private async Task<IMethodInvocationResult> GetWithoutCache(IAsyncMethodInvocation methodInvocation)
        {
            return await methodInvocation.InvokeNextAsync();
        }

        private async Task<IMethodInvocationResult> GetFromCache(IAsyncMethodInvocation methodInvocation)
        {
            var parentKey = GetClassAndMethodName(methodInvocation);

            //If call is not valid or not allowed to cache data, then just return the result ASAP
            var useCache = cache.Get<IDictionary<string, object>>(parentKey)
                .NoneWhenNullOrDefault(() => ResolveCacheDictionary(parentKey));

            var keyName = GetParamWithValueKey(methodInvocation);

            if (useCache.TryGetValue(keyName, out object cacheEntry))
                return methodInvocation.CreateResult(cacheEntry);

            var result = await methodInvocation.InvokeNextAsync();

            //add to cache when it is a sucess call
            if (result.Successful)
                useCache.Add(keyName, result.ReturnValue);

            return result;
        }

        private static string GetClassMethodParamAndValue(IAsyncMethodInvocation methodInvocation)
        {
            string methodWithClassName = GetClassAndMethodName(methodInvocation);

            StringBuilder sb = new StringBuilder(methodWithClassName);

            sb.Append(GetParamWithValueKey(methodInvocation));

            return sb.ToString();
        }

        private static string GetParamWithValueKey(IAsyncMethodInvocation methodInvocation)
        {
            var childElementKey = string.Join(",", methodInvocation.Arguments
                            .Select(x => new StringBuilder($"{x.ParameterInfo.Name}|{x.Value}")));

            return childElementKey;
        }

        private static string GetClassAndMethodName(IAsyncMethodInvocation methodInvocation)
        {
            var className = methodInvocation.TargetInstance.GetType().Name;

            var methodWithUserName = $"{className}={methodInvocation.MethodInfo.Name}=";
            return methodWithUserName;
        }

        private static bool IsValidMethodCall(IAsyncMethodInvocation methodInvocation)
        {
            var result = methodInvocation.InstanceMethodInfo.ReturnType != typeof(void)
                && methodInvocation.MethodInfo.GetCustomAttributes<ResolveFromCacheAttribute>() != null;

            return result;
        }

        private IDictionary<string, object> ResolveCacheDictionary(string parentKey)
        {
            var dict = new Dictionary<string, object>();

            cache.Set<IDictionary<string, object>>(parentKey, dict);

            return dict;
        }
    }
}
