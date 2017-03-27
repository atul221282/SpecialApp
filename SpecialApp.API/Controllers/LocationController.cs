using Microsoft.AspNetCore.Mvc;
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

        public LocationController(Func<ISpecialService> serviceFunc)
        {
            this.serviceFunc = serviceFunc;
        }
        [HttpGet("{distance}")]
        public async Task<IActionResult> Get(int distance)
        {
            var service = serviceFunc();
            return Ok(await service.GetLocation(-34.809964, 138.680274, distance: distance));
        }
    }
}
