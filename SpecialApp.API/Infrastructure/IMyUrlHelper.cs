using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SpecialApp.API.Infrastructure
{
    public interface IMyUrlHelper
    {
        IUrlHelper UrlHelper { get; }
    }

    public class MyUrlHelper : IMyUrlHelper
    {
        private readonly Func<IHttpContextAccessor> fact;
        private readonly IUrlHelper urlHelper;

        public MyUrlHelper(IUrlHelperFactory urlHelperFactory,
                   IActionContextAccessor actionContextAccessor)
        {
            this.urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
        public IUrlHelper UrlHelper => urlHelper;
    }
}