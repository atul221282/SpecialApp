using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service.Special;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var data = await service.GetLocations(-34.809964, 138.680274, distance: distance);
                var listData =(await data.WithAddress()).Resolve();
                return Ok(listData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
