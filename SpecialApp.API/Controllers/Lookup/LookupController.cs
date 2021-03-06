﻿using Microsoft.AspNetCore.Mvc;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.Entity.Companies;
using SpecialApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    public class LookupController : BaseApiController
    {
        private readonly Func<IBaseCodeService> serviceFunc;

        public LookupController(Func<IBaseCodeService> serviceFunc)
        {
            this.serviceFunc = serviceFunc;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            using (var service = serviceFunc())
            {
                if (name.IsNullOrWhiteSpace())
                    return StatusCode(404, SetError($"{name} related action not found"));

                var result = await service.GetByDictionary(name);

                return Ok(result);
            }
        }
    }
}
