using System;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Linq;

namespace SpecialApp.Service.Proxy.AddressTypeProxy
{
    public class PermitsSearchServiceInterceptor : Interceptor
    {
        protected override void ExecuteBefore(IInvocation invocation)
        {
            invocation.Arguments.ToList().ForEach(x =>
            {
                Debug.WriteLine(x);
            });
        }

        protected override void ExecuteAfter(IInvocation invocation)
        {
            Console.WriteLine("End");
        }
    }
}
