using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service.Special;
using System;
using System.Collections.Generic;
using SP = SpecialApp.Entity.Specials;
using System.Threading.Tasks;
using SpecialApp.Transport.Special;
using static System.String;

namespace SpecialApp.API.Controllers.Special
{
    public class SpecialController : BaseApiController
    {
        private readonly Func<ISpecialService> serviceFunc;

        public SpecialController(Func<ISpecialService> serviceFunc)
        {
            this.serviceFunc = serviceFunc;
        }

        [HttpGet("{distance}")]
        public async Task<IActionResult> GetAsync(int distance)
        {
            var service = serviceFunc();

            var data = await service.GetLocationsAsync(-34.809964, 138.680274, distance: distance);

            return EitherResponse(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateSpecial special)
        {
            return Ok(special);
        }
    }
}
