using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.Entity2;
using Microsoft.AspNetCore.Identity;

namespace SpecialApp.API.Controllers
{

    public class AuthController : BaseApiController
    {
        private readonly UserManager<SpecialAppUsers> userManager;

        public AuthController(UserManager<SpecialAppUsers> userManager)
        {
            this.userManager = userManager;
        }
        // GET: api/Auth
        public async Task<IActionResult> Get()
        {
            var user = await userManager.FindByEmailAsync("");
            return Ok(user);
        }

        // GET: api/Auth/5
        [HttpGet("{email}", Name = "Get")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return Ok(user);
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
                catch(Exception ex)
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
