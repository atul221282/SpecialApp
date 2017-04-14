using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Authorization;

namespace SpecialApp.API.Controllers
{
    [AllowAnonymous]
    public class UserAccountController : BaseApiController
    {
        private readonly UserManager<SpecialAppUsers> userManager;

        public UserAccountController(UserManager<SpecialAppUsers> userManager)
        {
            this.userManager = userManager;
        }
        // GET: api/UserAccount
        [HttpGet(Name = "GetUserAccount")]
        public async Task<IEnumerable<string>> Get()
        {
            var result = await userManager.FindByEmailAsync("bsharma2422@gmail.com");
            var result2 = await userManager.FindByEmailAsync("atul221282@gmail.com");

            var user = new SpecialAppUsers
            {
                Email = "bsharma2422@gmail.com",
                UserName = "bsharma2422@gmail.com",
                PhoneNumber = "0433277470"
            };

            var user2 = new SpecialAppUsers
            {
                Email = "atul221282@gmail.com",
                UserName = "atul221282@gmail.com",
                PhoneNumber = "0430499210"
            };

            if (result == null)
                await userManager.CreateAsync(user, "Cloudn@9");
            else
            {
                result.PhoneNumber = user.PhoneNumber;
                await userManager.UpdateAsync(result);
            }
            if (result2 == null)
                await userManager.CreateAsync(user2, "Cloudn@9");
            else
            {
                result2.PhoneNumber = user2.PhoneNumber;
                await userManager.UpdateAsync(result2);
            }

            result = await userManager.FindByEmailAsync("bsharma2422@gmail.com");
            result2 = await userManager.FindByEmailAsync("atul221282@gmail.com");

            return new string[] { $"{result.Email}-{result.PhoneNumber}", $"{result2.Email}-{result2.PhoneNumber}" };
        }

        // GET: api/UserAccount/5
        [HttpGet("{id}", Name = "GetUserAccountById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserAccount
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserAccount/5
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
