using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpecialApp.API.Filters;
using SpecialApp.API.StatePattern.AuthUser;
using SpecialApp.Base;
using SpecialApp.Context.Services;
using SpecialApp.Entity;
using SpecialApp.Entity.Model.Account;
using SpecialApp.Service;
using SpecialApp.Service.Account;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers.Account
{

    public class AuthController : BaseAccountApiController
    {
        private readonly Func<ICustomerService> customerServiceFunc;
        private IPasswordHasher<SpecialAppUsers> _hasher;
        private readonly Func<IPasswordHasher<SpecialAppUsers>> hasher;

        private ICustomerService _customerService;
        private readonly Func<ITokenService> tokenService;
        private readonly Func<IUserManagerService> managerServiceFunc;

        public ICustomerService CustomerService
        {
            get
            {
                return _customerService = _customerService ?? customerServiceFunc();
            }
        }

        public IPasswordHasher<SpecialAppUsers> Hasher
        {
            get
            {
                return _hasher = _hasher ?? hasher();
            }
        }

        public AuthController(Func<ICustomerService> customerServiceFunc,
            Func<IPasswordHasher<SpecialAppUsers>> hasher, Func<ITokenService> tokenService,
            Func<IUserManagerService> managerServiceFunc)
        {
            this.managerServiceFunc = managerServiceFunc;
            this.customerServiceFunc = customerServiceFunc;
            this.hasher = hasher;
            this.tokenService = tokenService;
        }

        [HttpGet(Name = "GetAuthUsers")]
        // GET: api/Auth
        public async Task<IActionResult> Get()
        {
            return Ok(await Task.FromResult(1));
        }

        // GET: api/Auth/5
        [HttpGet("{email}", Name = "GetAuthUserByEmail")]
        public async Task<IActionResult> Get(string email)
        {
            var result = await CustomerService.GetUser(email);
            return Ok(result.ResolveUser());
        }

        // POST: api/Auth
        [HttpPost(Name = "AuthLogin")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            using (CustomerService)
            {
                try
                {
                    var specialAppUser = await CustomerService.GetAppusers(model.EmailAddress);

                    var myAppUser = new AppUser(specialAppUser);

                    var appUserState = myAppUser.ResolveAppuser();

                    var result = appUserState.GetUserState();

                    var apiResponse = await result.GetVerifiedUser(managerServiceFunc(), hasher(), model.Password);

                    return apiResponse.GetResult(() =>
                    {
                        var tokenData = tokenService().GenerateToken(null, specialAppUser, model.RememberMe);

                        return new
                        {
                            token = tokenData.GetTokenString(),
                            expiration = tokenData.GetExpiry(),
                            expires_in = tokenData.GetExpiry()
                        };

                    });
                }
                catch (Exception)
                {
                    return BadRequest(SetError("Failed to login"));
                }
            }
        }
    }
}