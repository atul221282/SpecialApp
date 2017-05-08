using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StructureMap;
using SpecialApp.Entity;
using SpecialApp.Context.Infrastructure;
using SpecialApp.Entity.Infratsructure;
using AutoMapper;

namespace SpecialApp.API.Infrastructure
{
    public class ControllerRegistry : Registry
    {

        public ControllerRegistry(IServiceCollection services, Container container)
        {
            var mapper = AutomapperConfig.RegisterMapping();

            For<IMapper>().Use(mapper).Singleton();

            Scan(scan =>
            {
                scan.With(new ControllerConvention());
            });
        }
    }
}
