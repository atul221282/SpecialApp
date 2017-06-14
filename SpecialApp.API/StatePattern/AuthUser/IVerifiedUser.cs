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
    public interface IVerifiedUser
    {
        Task<IUserResult> GetVerifiedUser(IUserManagerService managerService,
            IPasswordHasher<SpecialAppUsers> hasher, string password);
    }
}
