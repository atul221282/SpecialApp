using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Context.Services;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public class AuthorisedUser : IAppUserState, IVerifiedUser
    {
        private readonly SpecialAppUsers user;

        public AuthorisedUser(SpecialAppUsers user)
        {
            this.user = user;
        }

        public IVerifiedUser GetUserState()
        {
            if (user == null)
                return new UnautorisedUser(user);

            return this;
        }

        public async Task<IUserResult> GetVerifiedUser(IUserManagerService managerService,
            IPasswordHasher<SpecialAppUsers> hasher, string password)
        {
            var result = hasher.VerifyHashedPassword((SpecialAppUsers)user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = hasher.HashPassword(user, password);
                await managerService.UpdateAsync((SpecialAppUsers)user);
            }

            return new ValidUserResult();
        }
    }
}
