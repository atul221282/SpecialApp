using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpecialApp.Base;
using SpecialApp.Context2;
using SpecialApp.Entity2;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(APIGlobalConstants.CorsPolicy, builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.Build();
                });
            });
        }

        public static void AddIdentityExtension(this IServiceCollection services)
        {
            services.AddIdentity<SpecialAppUsers, IdentityRole>()
                .AddEntityFrameworkStores<SpecialContext>();
        }

        public static Container AddIocExtension(this IServiceCollection services)
        {
            Func<IContainer> container = (() => SpecialObjectFactory.Container);

            container().Configure(config =>
            {
                config.Scan((y) =>
                {
                    y.TheCallingAssembly();
                    y.WithDefaultConventions();
                });
                // c.AddRegistry<PI.Config>();
                // c.AddRegistry<Business.Config>();
                // c.AddRegistry<StandardRegisrty>();
                // c.AddRegistry<ValidationConfig>();
                config.Populate(services);
            });
            // Populate the container using the service collection
            //return container.GetInstance<IServiceProvider>();
            return container() as Container;
        }
    }
}
