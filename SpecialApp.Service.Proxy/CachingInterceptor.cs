using Microsoft.Extensions.Caching.Memory;
using Optional;
using SpecialApp.Base;
using SpecialApp.Base.RulesEngine;
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

            this.CallWithOrWithoutCache.Add(true.ToString(), GetFromCacheAsync);
            this.CallWithOrWithoutCache.Add(false.ToString(), GetWithoutCacheAsync);
        }

        public async Task<IMethodInvocationResult> InterceptAsync(IAsyncMethodInvocation methodInvocation)
        {
            return await CallWithOrWithoutCache[IsValidMethodCall(methodInvocation).ToString()]
                .Invoke(methodInvocation);
        }

        private async static Task<IMethodInvocationResult> GetWithoutCacheAsync(IAsyncMethodInvocation methodInvocation)
            => await methodInvocation.InvokeNextAsync();

        private async Task<IMethodInvocationResult> GetFromCacheAsync(IAsyncMethodInvocation methodInvocation)
        {
            var parentKey = GetClassAndMethodName(methodInvocation);

            var useCache = cache.Get<IDictionary<string, object>>(parentKey)
                .NoneWhenNullOrDefault(() => ResolveCacheDictionary(parentKey));

            var keyName = GetParamWithValueKey(methodInvocation);

            return useCache.TryGetValue(keyName, out object cacheEntry)
                ? methodInvocation.CreateResult(cacheEntry)
                : await SetCacheAndReturnAsync(methodInvocation, useCache, keyName);
        }

        private static async Task<IMethodInvocationResult> SetCacheAndReturnAsync(IAsyncMethodInvocation methodInvocation, IDictionary<string, object> useCache, string keyName)
        {
            var resultIn = await methodInvocation.InvokeNextAsync();
            //add to cache when it is a sucess call
            resultIn.Successful.WhenTrue(() => useCache.Add(keyName, resultIn.ReturnValue));

            return resultIn;
        }

        private static string GetParamWithValueKey(IAsyncMethodInvocation methodInvocation)
        {
            var childElementKey = string.Join(",", methodInvocation.Arguments
                            .Select(x => new StringBuilder($"{x.ParameterInfo.Name}|{x.Value}")));

            return childElementKey.IsNullOrWhiteSpace()
                ? GetClassAndMethodName(methodInvocation)
                : childElementKey;
        }

        private static string GetClassAndMethodName(IAsyncMethodInvocation methodInvocation)
        {
            var className = methodInvocation.TargetInstance.GetType().Name;

            var methodWithUserName = $"{className}={methodInvocation.MethodInfo.Name}=";

            return methodWithUserName;
        }

        private static bool IsValidMethodCall(IAsyncMethodInvocation methodInvocation)
        {
            var result = new RuleStatement<bool>(
                () => methodInvocation.InstanceMethodInfo.ReturnType != typeof(void)
                    && methodInvocation.MethodInfo.GetCustomAttributes<ResolveFromCacheAttribute>() != null,
                new StopWithResultRule<bool>(true), new StopWithResultRule<bool>(false));

            var isValid= result.Process();

            return isValid;
            //return methodInvocation.InstanceMethodInfo.ReturnType != typeof(void)
            //    && methodInvocation.MethodInfo.GetCustomAttributes<ResolveFromCacheAttribute>() != null;
        }

        private IDictionary<string, object> ResolveCacheDictionary(string parentKey)
        {
            var dict = new Dictionary<string, object>();

            cache.Set<IDictionary<string, object>>(parentKey, dict);

            return dict;
        }
    }
}