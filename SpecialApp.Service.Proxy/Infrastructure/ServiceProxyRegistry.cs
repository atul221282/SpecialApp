using StructureMap;

namespace SpecialApp.Service.Proxy.Infrastructure
{
    public class ServiceProxyRegistry : Registry
    {
        public ServiceProxyRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}
