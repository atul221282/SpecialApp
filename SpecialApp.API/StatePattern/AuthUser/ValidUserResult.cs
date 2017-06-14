using Microsoft.AspNetCore.Identity;
using SpecialApp.Context.Services;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public class ValidUserResult : IUserResult
    {
        public ValidUserResult() { }

        public IActionResult GetResult<T>(Func<T> func)
        {
            return new OkObjectResult(func());
        }
    }
}
