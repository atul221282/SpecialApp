using SpecialApp.Base;
using SpecialApp.BusinessException.Infratsructure;
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
            IncludeRegistry<BusinessExceptionRegistry>();

            IncludeRegistry<UOWRegistry>();

            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}