using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

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
