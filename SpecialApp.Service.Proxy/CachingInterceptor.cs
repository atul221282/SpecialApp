using Microsoft.Extensions.Caching.Memory;
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
        private readonly string email;
        private readonly IDictionary<string, Func<IAsyncMethodInvocation, Task<IMethodInvocationResult>>> CallWhen
            = new Dictionary<string, Func<IAsyncMethodInvocation, Task<IMethodInvocationResult>>>();

        public CachingInterceptor(IMemoryCache cache, IUserIdentity identity)
        {
            this.cache = cache;
            this.identity = identity;

            this.CallWhen.Add(true.ToString(), GetFromCache);
            this.CallWhen.Add(false.ToString(), GetWithoutCache);
        }

        public async Task<IMethodInvocationResult> InterceptAsync(IAsyncMethodInvocation methodInvocation)
        {
            return await CallWhen[IsValidMethodCall(methodInvocation).ToString()]
                .Invoke(methodInvocation);
        }

        private async Task<IMethodInvocationResult> GetWithoutCache(IAsyncMethodInvocation methodInvocation)
        {
            return await methodInvocation.InvokeNextAsync();
        }

        private async Task<IMethodInvocationResult> GetFromCache(IAsyncMethodInvocation methodInvocation)
        {
            //If call is not valid or not allowed to cache data, then just return the result ASAP
            var keyName = CreateKeyFromMethodAndParam(methodInvocation);

            if (cache.TryGetValue(keyName, out object cacheEntry))
                return methodInvocation.CreateResult(cacheEntry);

            var result = await methodInvocation.InvokeNextAsync();

            //add to cache when it is a sucess call
            if (result.Successful)
                cache.Set(keyName, result.ReturnValue);

            return result;
        }

        private string CreateKeyFromMethodAndParam(IAsyncMethodInvocation methodInvocation)
        {
            var className = methodInvocation.TargetInstance.GetType().Name;

            var methodWithUserName = $"{className}={methodInvocation.MethodInfo.Name}=";

            StringBuilder sb = new StringBuilder(methodWithUserName);

            var childElementKey = string.Join(",", methodInvocation.Arguments
                .Select(x => new StringBuilder($"{x.ParameterInfo.Name}|{x.Value}")));

            sb.Append(childElementKey);

            return sb.ToString();
        }

        private bool IsValidMethodCall(IAsyncMethodInvocation methodInvocation)
        {
            var result =  methodInvocation.InstanceMethodInfo.ReturnType != typeof(void)
                && methodInvocation.MethodInfo.GetCustomAttributes<ResolveFromCacheAttribute>() != null;

            return result;
        }
    }
}
