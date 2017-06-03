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
using SpecialApp.Service.Account.Rules;
using SpecialApp.BusinessException;

namespace SpecialApp.Service.Account
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly Func<IUserManagerService> serviceFunc;
        private new ISpecialUOW _uow;
        private readonly IBusinessException busEx;
        public IAppUsers userResultType { get; private set; }

        private readonly Lazy<ISpecialUOW> uow;
        public ISpecialUOW Uow => _uow = _uow ?? uow.Value;

        private IUserManagerService _service;
        private readonly IBusinessRulesException busRules;

        public IUserManagerService Service
        {
            get
            {
                return _service = _service ?? serviceFunc();
            }
        }

        public CustomerService(Lazy<ISpecialUOW> uow, Func<IUserManagerService> serviceFunc,
            IBusinessException busEx, IBusinessRulesException busRules) : base(uow.Value)
        {
            this.serviceFunc = serviceFunc;
            this.busEx = busEx;
            this.uow = uow;
            this.busRules = busRules;
        }

        public async Task<Users> CreateAsync(RegisterCustomer model)
        {
            IRepository<Users> repo = null;

            var scope = await Uow.BeginTransaction();

            var result = await Service.FindByEmailAsync(model.EmailAddress);

            busRules.RulesFor(() => model)
                .WhenEmpty(x => x.FirstName)
                .AddError("FirstName", "First Name is manadatory")
                .When(x => x.EmailAddress.IsNotNullOrWhiteSpace())
                .AddError("EmailAddress", "Email Address is manadatory")
                .ThrowError();

            busEx
                .NullOrDefault(result, "User with same email address already exists", "SpecialAppUsers")
                .Empty(model.EmailAddress, "Email is required", "Email")
                .ErrorWhen(() => model.EmailAddress.IsNullOrWhiteSpace(), "", "")
                .RuleFor(() => model).When(x => x.EmailAddress.IsNotNullOrWhiteSpace())
                .ThrowIfErrors();

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
            var resolveUser = await GetUser(email);

            var specialAppUsers = await resolveUser.DeleteUsers(email, busEx);

            return specialAppUsers;
        }

        public async Task<IResolvedUser> GetUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                busEx.Add("SpecialAppUsers", "Email is required to find the user");
            }

            busEx.ThrowIfErrors();

            var result = await Service.GetUser(email);

            userResultType = result;

            return GetResolveUser();
        }

        private ResolvedUser GetResolveUser()
        {
            return new ResolvedUser(userResultType, Service, Uow);
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
