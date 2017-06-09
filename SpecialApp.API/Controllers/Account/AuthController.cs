using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpecialApp.API.Filters;
using SpecialApp.Base;
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
            IResolvedUser sss)
        {
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
                IAppUsers appUser;
                try
                {
                    var gAppUser = await CustomerService.GetUser(model.EmailAddress);

                    appUser = await gAppUser.ResolveUser(Hasher, model.Password);

                    return StatusCode(() => gAppUser.SetStatus((ser) =>
                    {
                        return appUser.ErrorMessage(SetAPIResponse(appUser, model.RememberMe), tokenService());
                    }, tokenService()));
                }
                catch (Exception)
                {
                    return StatusCode(() => Tuple.Create(500, SetError("Failed to login")));
                }
            }
        }

        private static Func<ITokenService, object> SetAPIResponse(IAppUsers appUser, bool rememberMe)
            => (serv) =>
        {
            var tokenData = serv.GenerateToken(null, appUser, rememberMe);
            return new
            {
                token = tokenData.GetTokenString(),
                expiration = tokenData.GetExpiry(),
                expires_in = tokenData.GetExpiry()
            };
        };

        private IActionResult StatusCode(Func<Tuple<int, object>> p)
        {
            var result = p();
            return StatusCode(result.Item1, result.Item2);
        }
    }
}