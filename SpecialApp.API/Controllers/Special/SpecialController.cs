using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service.Special;
using System;
using System.Collections.Generic;
using SP = SpecialApp.Entity.Specials;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get(int distance)
        {
            try
            {
                var service = serviceFunc();

                var specialOption = await service.GetById(99);

                var specialWithId = specialOption();

                var data = (await service.GetLocationsAsync(-34.809964, 138.680274, distance: distance));

                return EitherResponse(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
