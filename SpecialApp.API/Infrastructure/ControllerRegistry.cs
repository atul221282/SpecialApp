using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StructureMap;
using SpecialApp.Entity;
using SpecialApp.Context.Infrastructure;

namespace SpecialApp.API.Infrastructure
{
    public class ControllerRegistry : Registry
    {

        public ControllerRegistry(IServiceCollection services, Container container)
        {
            Scan(scan =>
            {
                scan.With(new ControllerConvention());
            });
        }
    }
}
