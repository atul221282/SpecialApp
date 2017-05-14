using Microsoft.AspNetCore.Mvc;
using SpecialApp.Entity.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers.Account
{
    public class FranchiseController : BaseAccountApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateFranchiseModel farnchiseModel)
        {
            return Ok();
        }
    }
}
