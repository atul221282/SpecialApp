using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Filters;
using SpecialApp.API.Helpers;

namespace SpecialApp.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ExceptionHandlerFilter]
    [EnableCors(APIGlobalConstants.CorsPolicy)]
    public abstract class BaseApiController : Controller
    {
        public virtual ObjectResult StatusCode(string message)
        {
            return StatusCode(500, new { Error = message });
        }

        public virtual BadRequestObjectResult BadRequest(string message)
        {
            return BadRequest(new { Error = message });
        }
    }
}