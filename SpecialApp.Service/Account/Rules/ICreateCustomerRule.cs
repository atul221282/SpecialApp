using SpecialApp.Entity;
using SpecialApp.Entity.Account;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Entity.Model.Account;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account.Rules
{
    public interface ICreateCustomerRule
    {
        Task<ICreateCustomerRule> Create(RegisterCustomer model);
    }

    public class CreateSpecialAppUser : ICreateCustomerRule
    {
        private readonly Func<RegisterCustomer, Task<ICreateCustomerRule>> f;
        private ICreateCustomerRule next;
        private ICreateCustomerRule createUser;

        public CreateSpecialAppUser(Func<RegisterCustomer, Task<ICreateCustomerRule>> f)
        {
            this.f = f;
        }

        public async Task<ICreateCustomerRule> Create(RegisterCustomer model)
        {
            next = await f(model);
            return next;
        }
    }

    public class CreateUser : ICreateCustomerRule
    {
        private readonly Func<RegisterCustomer, Task<ICreateCustomerRule>> f;
        private ICreateCustomerRule next;

        public CreateUser(Func<RegisterCustomer, Task<ICreateCustomerRule>> f)
        {
            this.f = f;
        }

        public async Task<ICreateCustomerRule> Create(RegisterCustomer model)
        {
            var next = await f(model);
            return next;
        }
    }

    public class StopCreateUser : ICreateCustomerRule
    {
        public async Task<ICreateCustomerRule> Create(RegisterCustomer model)
        {
            return await Task.Factory.StartNew(() => this);
        }
    }
}
