using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SpecialApp.Context.Services
{
    public interface IUserManagerService : IDisposable
    {
        Task<IdentityResult> CreateAsync(SpecialAppUsers users, string password);

        Task<SpecialAppUsers> FindByEmailAsync(string emailAddress);

        Task<IdentityResult> UpdateAsync(SpecialAppUsers users);

        Task<IdentityResult> DeleteAsync(SpecialAppUsers users);
    }
}
