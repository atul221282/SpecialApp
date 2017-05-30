using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Filters
{
    public class ProtectWithMultipleActionFilter : IAsyncActionFilter
    {
        private readonly string[] screens;
        private readonly string[] actions;
        private readonly short level;
        private readonly Func<ISecurityAdminPermissionService> serviceFunc;
        private readonly IUserIdentity identity;
        public ProtectWithMultipleActionFilter(string[] screens, string[] actions, short level, Func<ISecurityAdminPermissionService> serviceFunc, IUserIdentity identity)
        {
            this.actions = actions;
            this.screens = screens;
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

                if (!isAuthorized)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var results = await GetResult(screens, actions);

                if (results.Any(x => x >= level))
                {
                    await next();
                }
                else
                {

                    context.Result = new JsonResult(results)
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
            }
        }

        private async Task<IEnumerable<int>> GetResult(string[] screens, string[] actions)
        {
            using (var service = serviceFunc())
            {
                List<int> list = new List<int>();
                string userId = identity.GetEmail();

                for (int i = 0; i < screens.Length; i = i + 1)
                {
                    list.Add(await service.GetPermission(userId, screens[i], actions[i]));
                }
                return list;
            }
        }
    }
}
