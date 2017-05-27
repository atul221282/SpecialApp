using System;
using System.Threading.Tasks;
using SpecialApp.Context.Services;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Identity;

namespace SpecialApp.Service.Account
{
    public interface IResolvedUser
    {
        IAppUsers ResolveUser();

        /// <summary>
        /// This checks if user password need rehash and if yes then does the rehash
        /// </summary>
        /// <param name="hasher"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IAppUsers> ResolveUser(IPasswordHasher<SpecialAppUsers> hasher, string password);

        Tuple<int, object> SetStatus(Func<ITokenService, object> p, ITokenService service);
    }

    public class ResolvedUser : IResolvedUser
    {
        private readonly IAppUsers userResultType;
        private readonly IUserManagerService usrMngService;

        public ResolvedUser()
        {
            this.userResultType = UnauthorisedUser.Instance;
        }
        public ResolvedUser(IAppUsers userResultType, IUserManagerService usrMngService)
        {
            this.userResultType = userResultType ?? UnauthorisedUser.Instance;
            this.usrMngService = usrMngService;
        }

        public IAppUsers ResolveUser()
        {
            return userResultType;
        }

        public async Task<IAppUsers> ResolveUser(IPasswordHasher<SpecialAppUsers> hasher, string password)
        {
            if (userResultType is UnauthorisedUser || userResultType is AnonymousUser)
                return userResultType;

            var user = (SpecialAppUsers)userResultType;

            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
            {
                return UnauthorisedUser.Instance;
            }

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = hasher.HashPassword(user, password);
                await usrMngService.UpdateAsync(user);
            }

            return userResultType;
        }

        public Tuple<int, object> SetStatus(Func<ITokenService, object> p, ITokenService service)
        {
            return Tuple.Create(this.userResultType.StatusCode, this.userResultType.ErrorMessage(p, service));
        }
    }
}
