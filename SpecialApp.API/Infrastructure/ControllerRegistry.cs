using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StructureMap;
using SpecialApp.Entity;

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

        private SignInManager<SpecialAppUsers> GetSignInManager(IServiceCollection services)
        {
            try
            {
                var service = services.BuildServiceProvider();
                var instance = service.GetService<SignInManager<SpecialAppUsers>>();
                return instance;
            }
            catch
            {
                throw;
            }
        }

        private UserManager<SpecialAppUsers> GetUserManager(IServiceCollection services)
        {
            try
            {
                var service = services.BuildServiceProvider();
                var instance = service.GetService<UserManager<SpecialAppUsers>>();
                return instance;
            }
            catch
            {
                throw;
            }
        }
    }
}
