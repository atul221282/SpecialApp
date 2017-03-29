using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpecialApp.Entity.Options;
using SpecialApp.Service.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    public class LocationController : BaseApiController
    {
        private readonly Func<ISpecialService> serviceFunc;
        private readonly ConnectionStringsOptions options;

        public LocationController(Func<ISpecialService> serviceFunc, IOptions<ConnectionStringsOptions> options)
        {
            this.serviceFunc = serviceFunc;
            this.options = options.Value;
        }
        [HttpGet("{distance}")]
        public async Task<IActionResult> Get(int distance)
        {
            var service = serviceFunc();
            return Ok(await service.GetLocation(-34.809964, 138.680274, distance: distance));
        }
    }
}
