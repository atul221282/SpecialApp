using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpecialApp.Context;
using SpecialApp.Entity;
using SpecialApp.Entity.Options;
using StructureMap;
using System;

namespace SpecialApp.Context.Infrastructure
{
    public class ContextRegistry : Registry
    {
        public ContextRegistry(IServiceCollection services)
        {
            For<SpecialContext>().Use(x => GetContext<SpecialContext>(x));
            For<UserManager<SpecialAppUsers>>().Use<UserManager<SpecialAppUsers>>();
            For<SignInManager<SpecialAppUsers>>().Use<SignInManager<SpecialAppUsers>>();
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }

        private T GetContext<T>(IContext iContext) where T : DbContext
        {
            var _connectionStringOptions = iContext.TryGetInstance<IOptions<ConnectionStringsOptions>>();
            return (T)Activator.CreateInstance(typeof(T), _connectionStringOptions);
        }
    }
}