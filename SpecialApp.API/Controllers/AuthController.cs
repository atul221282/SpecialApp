using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.Entity2;
using Microsoft.AspNetCore.Identity;
using SpecialApp.API.Filters;

namespace SpecialApp.API.Controllers
{
    [ExceptionHandlerFilter]
    public class AuthController : BaseApiController
    {
        private readonly UserManager<SpecialAppUsers> userManager;
        private readonly IPasswordHasher<SpecialAppUsers> pwdHasher;

        public AuthController(UserManager<SpecialAppUsers> userManager, IPasswordHasher<SpecialAppUsers> pwdHasher)
        {
            this.userManager = userManager;
            this.pwdHasher = pwdHasher;
        }
        // GET: api/Auth
        public async Task<IActionResult> Get()
        {
            var user = await userManager.FindByEmailAsync("");
            return Ok(user);
        }

        // GET: api/Auth/5
        [HttpGet("{email}/{password}", Name = "Get")]
        public async Task<IActionResult> Get(string email, string password)
        {
            throw new Exception("cool");
            var user = await userManager.FindByEmailAsync(email);
            var rightUser = pwdHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (rightUser == PasswordVerificationResult.Success)
                return Ok(user);
            else
                return StatusCode(500);
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SpecialAppUsers user, [FromQuery]string password)
        {
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
