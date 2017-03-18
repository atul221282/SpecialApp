using StructureMap;

namespace SpecialApp.Service.Infrastructure
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}
