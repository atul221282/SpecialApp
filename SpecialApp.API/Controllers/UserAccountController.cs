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

namespace SpecialApp.API.Controllers
{
    public class UserAccountController : BaseApiController
    {
        private readonly Lazy<ISpecialUOW> uowFunc;
        private readonly Func<IUserManagerService> serviceFunc;

        private ISpecialUOW _uow;
        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uowFunc.Value;
            }
        }

        public UserAccountController(Lazy<ISpecialUOW> uowFunc, Func<IUserManagerService> serviceFunc)
        {
            this.serviceFunc = serviceFunc;
            this.uowFunc = uowFunc;
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
            IRepository<Users> repo = null;
            using (var service = serviceFunc())
            using (Uow)
            {
                var scope = await Uow.BeginTransaction();
                var result = await service.FindByEmailAsync(model.EmailAddress);

                if (result != null)
                    return StatusCode(500);

                var createdResult = await service.CreateAsync(new SpecialAppUsers
                {
                    Email = model.EmailAddress,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber
                }, password: model.Password);

                var newUser = await service.FindByEmailAsync(model.EmailAddress);

                if (createdResult.Succeeded)
                {
                    repo = Uow.GetRepository<Users>();
                    repo.Add(new Users
                    {
                        AuditCreatedBy = "system",
                        AuditCreatedDate = DateTimeOffset.Now,
                        AuditLastUpdatedBy = "system",
                        AuditLastUpdatedDate = DateTimeOffset.Now,
                        DOB = model.DateOfBirth,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        SpecialAppUsersId = newUser.Id,
                        State = State.Added,
                        IsDeleted = false
                    });
                }

                await Uow.CommitAsync();

                var addedUsers = await repo.GetAll().Include(x => x.SpecialAppUsers).FirstOrDefaultAsync();

                scope.Commit();

                return Ok(addedUsers);
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
