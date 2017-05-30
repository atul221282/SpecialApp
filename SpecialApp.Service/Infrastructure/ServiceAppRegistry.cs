using SpecialApp.Base;
using SpecialApp.UnitOfWork.Infrastructure;
using StructureMap;

namespace SpecialApp.Service.Infrastructure
{
    public class ServiceAppRegistry : Registry
    {
        public ServiceAppRegistry()
        {
            IncludeRegistry<UOWRegistry>();
            For(typeof(IOption<>)).Use(typeof(Option<>));
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}