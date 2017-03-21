using SpecialApp.Context.Infrastructure;
using StructureMap;

namespace SpecialApp.UnitOfWork.Infrastructure
{
    public class UOWRegistry : Registry
    {
        public UOWRegistry()
        {
            IncludeRegistry<ContextRegistry>();
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}