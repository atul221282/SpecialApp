using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpecialApp.Entity2;
using SpecialApp.Context2;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SpecialApp.API.Helpers;
using System;

namespace SpecialApp.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // add cors middle ware
            services.AddCorsExtension();
            // add identity and entity framework context to it
            services.AddContextAndIdentityExtension(Configuration);
            // add mvc middleware
            services.AddMvc();
            // add ioc extension
            var container = services.AddIocExtension();
            
            return container.GetInstance<IServiceProvider>();
            //return ConfigureIoC(services);
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(APIGlobalConstants.CorsPolicy);
            app.UseIdentity();
            app.UseMvc();
        }

    }
}
