using SpecialApp.Context;
using StructureMap;

namespace SpecialApp.Context.Infrastructure
{
    public class ContextRegistry : Registry
    {
        public ContextRegistry()
        {
            For<SpecialContext>().Use<SpecialContext>();
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}