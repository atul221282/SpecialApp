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
using SpecialApp.Entity.Model.Account;

namespace SpecialApp.API.Controllers.Account
{
    public class CustomerAccountController : BaseAccountApiController
    {
        private readonly Lazy<ISpecialUOW> uowFunc;
        private readonly Func<IUserManagerService> userManagerServiceFunc;
        private readonly Func<ICustomerService> custServiceFunc;
        private ISpecialUOW _uow;
        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uowFunc.Value;
            }
        }

        public CustomerAccountController(Func<ICustomerService> custServiceFunc, Func<IUserManagerService> serviceFunc)
        {
            this.userManagerServiceFunc = serviceFunc;
            this.custServiceFunc = custServiceFunc;
        }
        // GET: api/UserAccount
        [HttpGet(Name = "GetUserAccount")]
        public async Task<IEnumerable<string>> Get()
        {
            using (var custService = custServiceFunc())
            {
                var result = await custService.CreateTestAsync();

                return new string[] { result.Item1.Email, result.Item2.Email };
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
        [HttpDelete("{email}")]
        public async Task Delete(string email)
        {
            using (var custService = custServiceFunc())
            {
                var scope = await custService.BeginTransaction();

                await custService.DeleteAsync(email);

                await custService.CommitAsync();

                scope.Commit();
            }
        }

    }
}
