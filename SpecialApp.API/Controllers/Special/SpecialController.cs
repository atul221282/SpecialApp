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

                var specialOption = await service.GetById(99);

                //var sepcial = specialOption.ValueOr(() => new Entity.Specials.Special { });

                var specialWithId = specialOption();

                var data = (await service.GetLocations(-34.809964, 138.680274, distance: distance))();

                if (data.IsRight)
                {
                    // Get address
                    return Ok(data.Right);
                }

                return StatusCode(data.Left.GetCode(), data.Left.GetError());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
