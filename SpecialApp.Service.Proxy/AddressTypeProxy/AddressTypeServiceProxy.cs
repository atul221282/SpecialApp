using Castle.DynamicProxy;
using SpecialApp.UnitOfWork;
using System;

namespace SpecialApp.Service.Proxy.AddressTypeProxy
{
    public class AddressTypeServiceProxy : IAddressTypeServiceProxy
    {
        private readonly Func<IAddressTypeService> serviceFunc;
        private readonly Func<ProxyGenerator> generatorFunc;
        private readonly Func<PermitsSearchServiceInterceptor> interceptorFunc;

        public AddressTypeServiceProxy(Func<IAddressTypeService> serviceFunc,
            Func<ProxyGenerator> generatorFunc,
            Func<PermitsSearchServiceInterceptor> interceptorFunc)
        {
            this.serviceFunc = serviceFunc;
            this.generatorFunc = generatorFunc;
            this.interceptorFunc = interceptorFunc;
        }

        public IAddressTypeService GetService()
        {
            var generator = generatorFunc();

            var interceptor = interceptorFunc();

            var storage = generator.CreateInterfaceProxyWithTargetInterface(
                typeof(IAddressTypeService), serviceFunc(), interceptor);

            return storage as IAddressTypeService;

        }
    }
}
