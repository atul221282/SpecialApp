using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpecialApp.Context2;
using SpecialApp.Entity2;
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
    }
}
