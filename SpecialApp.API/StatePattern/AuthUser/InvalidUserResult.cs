using System;
using Microsoft.AspNetCore.Mvc;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public class InvalidUserResult : IUserResult
    {
        public InvalidUserResult() { }

        public IActionResult GetResult<T>(Func<T> func)
        {
            return new BadRequestObjectResult("Failed to Login");
        }
    }
}
