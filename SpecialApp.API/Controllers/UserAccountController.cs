using System.Collections.Generic;
using System.Threading.Tasks;
using SpecialApp.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Entity;
using System;
using SpecialApp.Context;
using SpecialApp.Entity.Account;
using System.Linq;
using SpecialApp.Context.Services;
using SpecialApp.UnitOfWork;
using SpecialApp.Repository;
using Microsoft.EntityFrameworkCore;
using SpecialApp.Service.Account;

namespace SpecialApp.API.Controllers
{
    public class UserAccountController : BaseApiController
    {
        private readonly Lazy<ISpecialUOW> uowFunc;
        private readonly Func<IUserManagerService> serviceFunc;
        private readonly Func<ICustomerService> custServiceFunc;
        private ISpecialUOW _uow;
        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uowFunc.Value;
            }
        }

        public UserAccountController(Func<ICustomerService> custServiceFunc, Func<IUserManagerService> serviceFunc)
        {
            this.serviceFunc = serviceFunc;
            this.custServiceFunc = custServiceFunc;
        }
        // GET: api/UserAccount
        [HttpGet(Name = "GetUserAccount")]
        public async Task<IEnumerable<string>> Get()
        {
            using (var userManager = serviceFunc())
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
        }

        // GET: api/UserAccount/5
        [HttpGet("{id}", Name = "GetUserAccountById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserAccount
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterCustomer model)
        {
            using (var custService = custServiceFunc())
            {
                return Ok(await custService.CreateAsync(model));
            }
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
