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

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]ClientLocation clientLocation)
        {
            var service = serviceFunc();

            const double lat = -34.809964, longi = 138.680274;

            var data = await service.GetLocationsAsync(clientLocation.Latitude, 
                clientLocation.Longitude, distance: 1000);

            return EitherResponse(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateSpecial special)
        {
            return Ok(special);
        }
    }
}
