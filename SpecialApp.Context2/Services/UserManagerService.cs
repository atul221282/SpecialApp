using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Base;
using System.Threading.Tasks;

namespace SpecialApp.Context.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly Func<UserManager<SpecialAppUsers>> userManagerFunc;
        private readonly Func<IBusinessException> busExFunc;

        public UserManagerService(Func<UserManager<SpecialAppUsers>> userManagerFunc, Func<IBusinessException> busExFunc)
        {
            this.userManagerFunc = userManagerFunc;
            this.busExFunc = busExFunc;
        }

        public async Task<IdentityResult> CreateUser(SpecialAppUsers users, string password)
        {
            using (var userMgr = userManagerFunc())
            {
                var result = await userMgr.FindByEmailAsync(users.Email);
                if (result == null)
                {
                    var busex = busExFunc();
                    busex.Add("EmailAddress", "Email address already exists");
                    busex.ThrowIfErrors();
                }
                return await userMgr.CreateAsync(users, password);
            }
        }
    }
}
