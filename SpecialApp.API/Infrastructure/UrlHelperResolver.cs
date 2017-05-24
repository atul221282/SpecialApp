using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SpecialApp.API.Infrastructure
{
    public interface IUrlHelperResolver
    {
        IUrlHelper UrlHelper { get; }
    }

    public class UrlHelperResolver : IUrlHelperResolver
    {
        private readonly Func<IHttpContextAccessor> fact;
        private readonly IUrlHelper urlHelper;

        public UrlHelperResolver(IUrlHelperFactory urlHelperFactory,
                   IActionContextAccessor actionContextAccessor)
        {
            this.urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
        public IUrlHelper UrlHelper => urlHelper;
    }
}