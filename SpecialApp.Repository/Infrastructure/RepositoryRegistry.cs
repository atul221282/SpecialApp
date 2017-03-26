using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Repository.Infrastructure
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}
