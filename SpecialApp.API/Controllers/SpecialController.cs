using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    public class SpecialController : BaseApiController
    {
        private readonly Func<ISpecialService> serviceFunc;

        public SpecialController(Func<ISpecialService> serviceFunc)
        {
            this.serviceFunc = serviceFunc;
        }
        public async Task<IActionResult> Get()
        {
            try
            {
                var service = serviceFunc();
                return Ok(await service.GetByLocation(-34.809964, 138.680274));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
