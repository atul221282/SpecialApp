using System;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Identity;
using SpecialApp.Base;
using System.Threading.Tasks;

namespace SpecialApp.Context.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly Lazy<UserManager<SpecialAppUsers>> userManager;
        private readonly Func<IBusinessException> busExFunc;

        private UserManager<SpecialAppUsers> _userManager;
        public UserManager<SpecialAppUsers> UserManager
        {
            get
            {
                return _userManager = _userManager ?? userManager.Value;
            }
        }

        public UserManagerService(Lazy<UserManager<SpecialAppUsers>> userManager, Func<IBusinessException> busExFunc)
        {
            this.userManager = userManager;
            this.busExFunc = busExFunc;
        }

        public async Task<IdentityResult> CreateAsync(SpecialAppUsers users, string password)
        {
            var result = await UserManager.FindByEmailAsync(users.Email);
            if (result != null)
            {
                var busex = busExFunc();
                busex.Add("EmailAddress", "Email address already exists");
                busex.ThrowIfErrors();
            }
            return await UserManager.CreateAsync(users, password);
        }

        public async Task<SpecialAppUsers> FindByEmailAsync(string emailAddress)
        {
            return await UserManager.FindByEmailAsync(emailAddress);
        }

        public async Task<IdentityResult> DeleteAsync(SpecialAppUsers users)
        {
            return await UserManager.DeleteAsync(users);
        }

        public async Task<IdentityResult> UpdateAsync(SpecialAppUsers users)
        {
            return await UserManager.UpdateAsync(users);
        }

        public void Dispose()
        {
            UserManager.Dispose();
        }

        public async Task<IAppUsers> GetUser(string email)
        {
            var result = (await UserManager.FindByEmailAsync(email));



            return result?.Resolve() ?? UnauthorisedUser.Instance;
        }
    }
}
