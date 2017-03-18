using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors(APIGlobalConstants.CorsPolicy)]
    public abstract class BaseApiController : Controller
    {
        public OkObjectResult Ok<T>(T data)
        {
            return Ok(data);
        }
    }
}
