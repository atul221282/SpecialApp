using SpecialApp.UnitOfWork;
using StructureMap;

namespace SpecialApp.Service.Infrastructure
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            IncludeRegistry<UOWRegistry>();
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}