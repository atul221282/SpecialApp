﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpecialApp.Base;
using SpecialApp.Base.Infrastructure;
using SpecialApp.Context;
using SpecialApp.Entity;
using SpecialApp.Service.Infrastructure;
using StructureMap;
using System;
using SpecialApp.API.Infrastructure;

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

        public static void AddContextAndIdentityExtension(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SpecialContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddIdentity<SpecialAppUsers, IdentityRole>()
                .AddEntityFrameworkStores<SpecialContext>()
                .AddDefaultTokenProviders();
        }

        public static Container AddIocExtension(this IServiceCollection services, Container container)
        {
            //Func<IContainer> container = (() => SpecialObjectFactory.Container);

            container.Configure(config =>
            {
                config.AddRegistry(new ControllerRegistry(services, container));
                config.Scan((y) =>
                {
                    y.TheCallingAssembly();
                    y.WithDefaultConventions();
                });
                config.AddRegistry<BaseRegistry>();
                config.AddRegistry<ServiceRegistry>();
                config.Populate(services);
            });
            // Populate the container using the service collection
            //return container.GetInstance<IServiceProvider>();
            return container;
        }

        public static void AddSpecialAppCompression(this IServiceCollection services)
        {
            //https://www.softfluent.com/blog/dev/2017/01/13/Enabling-gzip-compression-with-ASP-NET-Core
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();
        }

        public static void PreLoadContainer(this Container container, IConfigurationRoot config)
        {
            container.Configure(scan =>
            {
                scan.ForSingletonOf<IConfigurationRoot>().Use(config);
                scan.For<IHttpContextAccessor>().Use<HttpContextAccessor>().ContainerScoped();
            });
        }
        
    }
}