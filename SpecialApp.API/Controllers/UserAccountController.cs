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
        //private readonly UserManager<SpecialAppUsers> userManager;

        public UserAccountController()
        {
            //this.userManager = userManager;
        }
        // GET: api/UserAccount
        [HttpGet(Name ="GetUserAccount")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserAccount/5
        [HttpGet("{id}", Name = "Get")]
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
