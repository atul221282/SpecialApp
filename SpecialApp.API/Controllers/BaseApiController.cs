using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Helpers;

namespace SpecialApp.API.Controllers
{
    [Route("api/[controller]")]
    //[Produces("application/json")]
    [EnableCors(APIGlobalConstants.CorsPolicy)]
    public abstract class BaseApiController : Controller
    {
    }
}