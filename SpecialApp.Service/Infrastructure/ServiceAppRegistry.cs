using SpecialApp.Base;
using SpecialApp.BusinessException.Infratsructure;
using SpecialApp.Entity;
using SpecialApp.Service.Proxy;
using SpecialApp.UnitOfWork.Infrastructure;
using StructureMap;
using StructureMap.DynamicInterception;
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

            For<IAddressTypeService>().Use<AddressTypeService>()
            .InterceptWith(new DynamicProxyInterceptor<IAddressTypeService>(
                new[] { typeof(ICachingInterceptor) }));

            Scan(y =>
            {
                y.Exclude((x) =>
                {
                    return x.GetType() == typeof(ICacheService);
                });
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}