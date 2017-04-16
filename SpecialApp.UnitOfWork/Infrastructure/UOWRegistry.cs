using SpecialApp.Context.Infrastructure;
using StructureMap;

namespace SpecialApp.UnitOfWork.Infrastructure
{
    public class UOWRegistry : Registry
    {
        public UOWRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}