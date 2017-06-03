using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.UnitOfWork.Infrastructure;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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