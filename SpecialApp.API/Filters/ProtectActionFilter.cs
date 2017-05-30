using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.API.Filters
{
    public class ProtectActionFilter : IAsyncActionFilter
    {
        private readonly string screen;
        private readonly string action;
        private readonly short level;
        private readonly Func<ISecurityAdminPermissionService> serviceFunc;
        private readonly IUserIdentity identity;

        public ProtectActionFilter(string screen, string action, short level, Func<ISecurityAdminPermissionService> serviceFunc, IUserIdentity identity)
        {
            this.action = action;
            this.screen = screen;
            this.level = level;
            this.serviceFunc = serviceFunc;
            this.identity = identity;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool isAuthorized = context.HttpContext.User.Identity.IsAuthenticated;

            using (var service = serviceFunc())
            {
                string userId = identity.GetEmail();

                var result = await service.GetPermission(userId, screen, action);

                if (!isAuthorized)
                {
                    context.Result = new UnauthorizedResult();

                    return;
                }

                if (result < level)
                {
                    context.Result = new JsonResult(result)
                    {
                        StatusCode = 403,
                        Value = new
                        {
                            Errors = new Dictionary<string, string>
                            {
                                ["Error"] = "Access Denied. Please contact your administrator."
                            }
                        }
                    };

                    return;

                }

                await next();
            }
        }
    }
}
