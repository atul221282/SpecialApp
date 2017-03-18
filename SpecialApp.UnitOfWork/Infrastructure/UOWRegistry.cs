using SpecialApp.Context.Infrastructure;
using StructureMap;
using System;

namespace SpecialApp.UnitOfWork.Infrastructure
{
    public class UOWRegistry:Registry
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
