using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service.Special;
using System;
using System.Collections.Generic;
using SP = SpecialApp.Entity.Specials;
using System.Threading.Tasks;
using SpecialApp.Transport.Special;
using static System.String;
using SpecialApp.Base;
using SpecialApp.Entity;

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

            var lat = -34.809964;
            var longi = 138.680274;

            var data = await service.GetLocationsAsync(lat, longi, distance: distance);

            var data2 = await service.GetByLocation(lat, longi);

            var data3 = await service.GetLocation(lat, longi);

            var tt = EitherComposite.Combine(data, data2, data3);

            var ghg = tt.IsFailure;

            var errors = tt.Error;

            return EitherResponse(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateSpecial special)
        {
            return Ok(special);
        }
    }
}
