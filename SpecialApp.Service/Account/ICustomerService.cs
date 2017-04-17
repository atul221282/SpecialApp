using SpecialApp.Entity;
using SpecialApp.Entity.Account;
using SpecialApp.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public interface ICustomerService : IBaseService
    {
        Task<Users> CreateAsync(RegisterCustomer model);

        Task<Tuple<SpecialAppUsers, SpecialAppUsers>> CreateTestAsync();
    }
}
