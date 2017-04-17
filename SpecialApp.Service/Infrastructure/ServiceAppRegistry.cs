using SpecialApp.UnitOfWork.Infrastructure;
using StructureMap;

namespace SpecialApp.Service.Infrastructure
{
    public class ServiceAppRegistry : Registry
    {
        public ServiceAppRegistry()
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