using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Filters;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.Entity.Model.Account;
using System;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers.Account
{
    [ExceptionHandlerFilter]
    public class AuthController : BaseAccountApiController
    {
        public AuthController()
        {
        }

        [HttpGet(Name ="GetAuth")]
        // GET: api/Auth
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET: api/Auth/5
        [HttpGet("{email}", Name = "GetAuthByName")]
        public async Task<IActionResult> Get(string email)
        {
            return Ok();
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginModel model)
        {
            return Ok();
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