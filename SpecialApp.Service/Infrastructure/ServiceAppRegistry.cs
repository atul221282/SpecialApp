
using StructureMap;

namespace SpecialApp.Service.Infrastructure
{
    public class ServiceAppRegistry : Registry
    {
        public ServiceAppRegistry()
        {
            
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}
