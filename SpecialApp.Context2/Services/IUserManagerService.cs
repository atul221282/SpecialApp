using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SpecialApp.Context.Services
{
    public interface IUserManagerService
    {
        Task<IdentityResult> CreateUser(SpecialAppUsers users, string password);
    }
}
