using Castle.DynamicProxy;
using SpecialApp.Service.Proxy.AddressTypeProxy;
using StructureMap;

namespace SpecialApp.Service.Proxy.Infrastructure
{
    public class ServiceProxyRegistry : Registry
    {
        public ServiceProxyRegistry()
        {
            For<ProxyGenerator>().Use((x) => GetProxyGenerator(x));
            For<PermitsSearchServiceInterceptor>().Use((x) => GetPermitsServiceInterceptor(x));
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }

        private PermitsSearchServiceInterceptor GetPermitsServiceInterceptor(IContext arg)
        {
            return new PermitsSearchServiceInterceptor();
        }

        private ProxyGenerator GetProxyGenerator(IContext arg)
        {
            return new ProxyGenerator();
        }
    }
}
