using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public interface IUserResult
    {
        IActionResult GetResult<T>(Func<T> func);
    }
}
