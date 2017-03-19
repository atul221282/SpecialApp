using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Infrastructure
{
    public class BaseRegistry : Registry
    {
        public BaseRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}
