using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpecialApp.Entity.Account;
using SpecialApp.Entity.Model;
using SpecialApp.UnitOfWork;
using SpecialApp.Repository;
using SpecialApp.Context.Services;
using SpecialApp.Base;
using SpecialApp.Entity;
using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity.Helpers;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Entity.Model.Account;

namespace SpecialApp.Service.Account
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly Func<IUserManagerService> serviceFunc;
        private ISpecialUOW _uow;
        private readonly IBusinessException busEx;

        private readonly Lazy<ISpecialUOW> uow;
        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uow.Value;
            }
        }

        private IUserManagerService _service;

        public IUserManagerService Service
        {
            get
            {
                return _service = _service ?? serviceFunc();
            }
        }


        public CustomerService(Lazy<ISpecialUOW> uow, Func<IUserManagerService> serviceFunc,
            IBusinessException busEx) : base(uow.Value)
        {
            this.serviceFunc = serviceFunc;
            this.busEx = busEx;
            this.uow = uow;
        }

        /// <summary>
        /// Create new SpecialAppUsers and users if user with same email doesnot exists
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Users> CreateAsync(RegisterCustomer model)
        {
            IRepository<Users> repo = null;

            var scope = await Uow.BeginTransaction();
            var result = await Service.FindByEmailAsync(model.EmailAddress);

            if (result != null)
                busEx.Add("SpecialAppUsers", "User with same email address already exists");

            busEx.ThrowIfErrors();

            var createdResult = await Service.CreateAsync(new SpecialAppUsers
            {
                Email = model.EmailAddress,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber
            }, password: model.Password);

            var newUser = await Service.FindByEmailAsync(model.EmailAddress);

            if (createdResult.Succeeded)
            {
                repo = Uow.GetRepository<Users>();
                var users = new Users
                {
                    DOB = model.DateOfBirth,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SpecialAppUsersId = newUser.Id,
                    State = State.Added
                };
                repo.Add(users.SetDefaults(loggedInUser: string.Empty));

                await Uow.CommitAsync();

                var addedUsers = await repo.GetAll().Include(x => x.SpecialAppUsers).FirstOrDefaultAsync();

                scope.Commit();

                return addedUsers;
            }
            return null;
        }

        public async Task<Tuple<SpecialAppUsers, SpecialAppUsers>> CreateTestAsync()
        {
            var result = await Service.FindByEmailAsync("bsharma2422@gmail.com");
            var result2 = await Service.FindByEmailAsync("atul221282@gmail.com");

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
                await Service.CreateAsync(user, "Cloudn@9");
            else
            {
                result.PhoneNumber = user.PhoneNumber;
                await Service.UpdateAsync(result);
            }

            if (result2 == null)
                await Service.CreateAsync(user2, "Cloudn@9");
            else
            {
                result2.PhoneNumber = user2.PhoneNumber;
                await Service.UpdateAsync(result2);
            }

            result = await Service.FindByEmailAsync("bsharma2422@gmail.com");
            result2 = await Service.FindByEmailAsync("atul221282@gmail.com");

            return new Tuple<SpecialAppUsers, SpecialAppUsers>(result, result2);
        }

        public async Task<IdentityResult> DeleteAsync(string email)
        {
            var specialAppUsers = await Service.FindByEmailAsync(email);
            if (specialAppUsers == null)
                busEx.Add("SpecialAppUsers", $"No user found for {email}");

            busEx.ThrowIfErrors();
            var repo = Uow.GetRepository<Users>();
            var users = await repo.GetAll().FirstOrDefaultAsync(x => x.SpecialAppUsersId == specialAppUsers.Id);

            if (users == null)
                busEx.Add("Users", $"No user found for {email}");

            busEx.ThrowIfErrors();

            await repo.Delete(users);
            return await Service.DeleteAsync(specialAppUsers);
        }

        public async Task<SpecialAppUsers> FindByEmailAsync(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                busEx.Add("SpecialAppUsers", "Email is required to find the user");
            }
            busEx.ThrowIfErrors();
            return await Service.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> UpdateAsync(SpecialAppUsers user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var result = await Service.UpdateAsync(user);

            return result;
        }
    }
}
