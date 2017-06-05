using Castle.DynamicProxy;
using SpecialApp.UnitOfWork;
using System;

namespace SpecialApp.Service.Proxy
{
    public abstract class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            ExecuteBefore(invocation);
            invocation.Proceed();
            ExecuteAfter(invocation);

        }
        protected abstract void ExecuteAfter(IInvocation invocation);
        protected abstract void ExecuteBefore(IInvocation invocation);
    }

    
}
