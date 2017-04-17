﻿using Microsoft.AspNetCore.Identity;
using SpecialApp.Entity;
using SpecialApp.Entity.Account;
using SpecialApp.Entity.Model.Account;
using System;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public interface ICustomerService : IBaseService
    {
        Task<Users> CreateAsync(RegisterCustomer model);

        Task<Tuple<SpecialAppUsers, SpecialAppUsers>> CreateTestAsync();

        Task<IdentityResult> DeleteAsync(string email);

        Task<SpecialAppUsers> FindByEmailAsync(string email);

        Task<IdentityResult> UpdateAsync(SpecialAppUsers user);
    }
}
