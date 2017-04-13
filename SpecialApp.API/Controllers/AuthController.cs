using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Filters;
using SpecialApp.Base;
using SpecialApp.Entity;
using System;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    [ExceptionHandlerFilter]
    public class AuthController : BaseApiController
    {
        private readonly Func<UserManager<SpecialAppUsers>> userManagerFunc;
        private readonly Func<IPasswordHasher<SpecialAppUsers>> pwdHasherFunc;
        private readonly IBusinessException busEx;

        public AuthController(Func<UserManager<SpecialAppUsers>> userManagerFunc,
           Func<IPasswordHasher<SpecialAppUsers>> pwdHasherFunc,
            IBusinessException busEx)
        {
            this.userManagerFunc = userManagerFunc;
            this.pwdHasherFunc = pwdHasherFunc;
            this.busEx = busEx;
        }

        [HttpGet(Name ="GetAuth")]
        // GET: api/Auth
        public async Task<IActionResult> Get()
        {
            var userManager = userManagerFunc();
            var user = await userManager.FindByEmailAsync("");
            return Ok(user);
        }

        // GET: api/Auth/5
        [HttpGet("{email}", Name = "GetAuthByName")]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                var userManager = userManagerFunc();
                var user = await userManager.FindByEmailAsync(email);
                if (user != null)
                    return Ok(user);
                else
                    return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SpecialAppUsers user, [FromQuery]string password)
        {
            var userManager = userManagerFunc();
            if (user != null)
            {
                try
                {
                    var userResult = await userManager.FindByEmailAsync(user.Email);
                    if (userResult != null)
                        return StatusCode(500);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            var result = await userManager.CreateAsync(user, password);
            return Ok(result);
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}