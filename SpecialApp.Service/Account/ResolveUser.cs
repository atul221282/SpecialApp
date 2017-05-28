using System;
using System.Threading.Tasks;
using SpecialApp.Context.Services;
using SpecialApp.Entity;
using Microsoft.AspNetCore.Identity;
using SpecialApp.UnitOfWork;
using SpecialApp.Base;
using SpecialApp.Entity.Account;
using Microsoft.EntityFrameworkCore;

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

        Tuple<int, object> SetStatus(Func<ITokenService, object> getErrorResponse, ITokenService service);

        Task<IdentityResult> DeleteUsers(string email, IBusinessException busEx);
    }

    public class ResolvedUser : IResolvedUser
    {
        private IAppUsers userResultType { get; set; }
        private readonly IUserManagerService usrMngService;
        private readonly ISpecialUOW uow;

        public ResolvedUser()
        {
            this.userResultType = UnauthorisedUser.Instance;
        }

        public ResolvedUser(IAppUsers userResultType, IUserManagerService usrMngService, ISpecialUOW uow)
        {
            this.userResultType = userResultType ?? UnauthorisedUser.Instance;
            this.usrMngService = usrMngService;
            this.uow = uow;
        }

        public IAppUsers ResolveUser()
        {
            return userResultType;
        }

        public async Task<IAppUsers> ResolveUser(IPasswordHasher<SpecialAppUsers> hasher, string password)
        {
            if (userResultType is UnauthorisedUser || userResultType is AnonymousUser)
                return userResultType;

            var user = userResultType;

            var result = hasher.VerifyHashedPassword((SpecialAppUsers)user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
            {
                userResultType = UnauthorisedUser.Instance;
                return UnauthorisedUser.Instance;
            }

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                userResultType = (SpecialAppUsers)user;
                user.PasswordHash = hasher.HashPassword((SpecialAppUsers)user, password);
                await usrMngService.UpdateAsync((SpecialAppUsers)user);
            }

            return userResultType;
        }

        /// <summary>
        /// This method must be wrapped under transaction
        /// </summary>
        /// <param name="email"></param>
        /// <param name="busEx"></param>
        /// <returns></returns>
        public async Task<IdentityResult> DeleteUsers(string email, IBusinessException busEx)
        {
            if (userResultType is UnauthorisedUser || userResultType is AnonymousUser)
                busEx.Add("SpecialAppUsers", $"No user found for {email}");

            busEx.ThrowIfErrors();

            var repo = uow.GetRepository<Users>();

            var users = await repo.GetAllActive().FirstOrDefaultAsync(x => x.SpecialAppUsersId == userResultType.Id);

            if (users == null)
                busEx.Add("Users", $"No user found for {email}");

            busEx.ThrowIfErrors();

            await repo.Delete(users);

            return await usrMngService.DeleteAsync((SpecialAppUsers)userResultType);
        }

        public Tuple<int, object> SetStatus(Func<ITokenService, object> getErrorResponse, ITokenService service)
        {
            return Tuple.Create(userResultType.StatusCode, userResultType.ErrorMessage(getErrorResponse, service));
        }
    }
}
