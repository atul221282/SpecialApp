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

namespace SpecialApp.API.Controllers
{
    public class UserAccountController : BaseApiController
    {
        private readonly Func<UserManager<SpecialAppUsers>> userManagerFunc;
        private readonly Func<SpecialContext> ctxFunc;
        private readonly Func<IUserManagerService> serviceFunc;

        public UserAccountController(Func<UserManager<SpecialAppUsers>> userManagerFunc,
            Func<SpecialContext> ctxFunc, Func<IUserManagerService> serviceFunc)
        {
            this.userManagerFunc = userManagerFunc;
            this.ctxFunc = ctxFunc;
            this.serviceFunc = serviceFunc;
        }
        // GET: api/UserAccount
        [HttpGet(Name = "GetUserAccount")]
        public async Task<IEnumerable<string>> Get()
        {
            using (var userManager = userManagerFunc())
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
            model.DateOfBirth = model.DateOfBirth.Value.ToLocalTime();
            using (var userManager = userManagerFunc())
            using (var ctx = ctxFunc())
            {
                var result = await userManager.FindByEmailAsync(model.EmailAddress);
                if (result == null)
                {
                    var result2 = await userManager.CreateAsync(new SpecialAppUsers
                    {
                        Email = model.EmailAddress,
                        UserName = model.UserName,
                        PhoneNumber = model.PhoneNumber,
                    }, model.Password);
                }
                result = await userManager.FindByEmailAsync(model.EmailAddress);
                var user = new Users
                {
                    DOB = model.DateOfBirth,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    State = State.Added,
                    AuditCreatedBy = "system",
                    AuditCreatedDate = DateTimeOffset.Now,
                    AuditLastUpdatedBy = "system",
                    AuditLastUpdatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    SpecialAppUsersId = null//result.Id
                };
                if (result == null)
                    ctx.Users.Add(user);
                else
                {
                    user = ctx.Users.Where(x => x.SpecialAppUsersId == result.Id).FirstOrDefault();
                    user.DOB = model.DateOfBirth;
                    ctx.Update(user);
                }

                ctx.SaveChanges();

                return Ok(model);
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
