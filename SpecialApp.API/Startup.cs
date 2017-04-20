using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SpecialApp.API.Helpers;
using SpecialApp.Base;
using SpecialApp.Context;
using SpecialApp.Entity;
using SpecialApp.Entity.Options;
using StructureMap;
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

            var container = SpecialObjectFactory.Container;

            container.PreLoadContainer(Configuration);

            // add identity and entity framework context to it
            services.AddContextAndIdentityExtension(Configuration);
            // Adds services required for using options.
            services.AddOptions();
            // Configure with Microsoft.Extensions.Options.ConfigurationExtensions
            // Binding the whole configuration should be rare, subsections are more typical.
            services.Configure<ConnectionStringsOptions>(Configuration.GetSection("ConnectionStrings"));

            services.AddSpecialChallenge();

            // add mvc middleware
            services.AddMvc().AddJsonOptions(opt =>
            {
                var resolver = opt.SerializerSettings.ContractResolver;
                opt.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;  // <<!-- this removes the camelcasing
                }
            });
            //// add ioc extension
            //services.AddSpecialAppCompression();

            services.AddIocExtension(container);
            return container.GetInstance<IServiceProvider>();
            //return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseResponseCompression();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(APIGlobalConstants.CorsPolicy);
            app.UseIdentity();
            app.UseMvc();
        }
    }
}