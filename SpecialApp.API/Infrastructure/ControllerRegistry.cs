using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StructureMap;
using SpecialApp.Entity;
using SpecialApp.Context.Infrastructure;
using SpecialApp.Entity.Infratsructure;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SpecialApp.API.Infrastructure
{
    public class ControllerRegistry : Registry
    {

        public ControllerRegistry(IServiceCollection services, Container container)
        {
            //var ff = container.GetInstance<IActionContextAccessor>();
            var mapper = AutomapperConfig.RegisterMapping();
            For<IMapper>().Use(mapper).Singleton();

            Scan(scan =>
            {
                scan.With(new ControllerConvention());
            });
        }

        private UrlHelper GetK(IContext x)
        {
            var ff = x.GetInstance<IActionContextAccessor>();
            return new UrlHelper(ff.ActionContext);
        }
        

    }
}
