using SpecialApp.Repository.Infrastructure;
using SpecialApp.UnitOfWork;
using StructureMap;

namespace SpecialApp.Service.Infrastructure
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            IncludeRegistry<UOWRegistry>();
            //IncludeRegistry<RepositoryRegistry>();
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}