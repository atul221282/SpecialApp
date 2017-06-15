using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.Context.Services;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public class UnautorisedUser : IAppUserState, IVerifiedUser
    {
        private readonly SpecialAppUsers users;

        public UnautorisedUser(SpecialAppUsers users)
        {
            this.users = users;
        }
        public IVerifiedUser GetUserState()
        {
            if (users == null)
                return this;

            return new AuthorisedUser(users);
        }

        public async Task<IUserResult> GetVerifiedUser(IUserManagerService managerService,
            IPasswordHasher<SpecialAppUsers> hasher, string password) => await Task.FromResult(new InvalidUserResult());
    }
}
