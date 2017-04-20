using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Filters;
using SpecialApp.API.Helpers;
using System.Collections.Generic;

namespace SpecialApp.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ExceptionHandlerFilter]
    [EnableCors(APIGlobalConstants.CorsPolicy)]
    public abstract class BaseApiController : Controller
    {
        protected virtual object SetError(string message)
        {
            return new
            {
                Errors = new Dictionary<string, string>
                {
                    ["Error"] = message
                }
            };
        }
    }
}