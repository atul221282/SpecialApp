using SpecialApp.Context2;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

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
