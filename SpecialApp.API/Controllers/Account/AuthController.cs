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
    [ExceptionHandlerFilter]
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
            Func<IPasswordHasher<SpecialAppUsers>> hasher, Func<ITokenService> tokenService)
        {
            this.customerServiceFunc = customerServiceFunc;
            this.hasher = hasher;
            this.tokenService = tokenService;
        }

        [HttpGet(Name = "GetAuth")]
        // GET: api/Auth
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET: api/Auth/5
        [HttpGet("{email}", Name = "GetAuthByName")]
        public async Task<IActionResult> Get(string email)
        {
            return Ok();
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginModel model)
        {
            using (CustomerService)
            {
                IAppUsers appUser;
                try
                {
                    var gAppUser = await CustomerService.GetUser(model.EmailAddress);

                    appUser = await gAppUser.ResolveUserStatus(Hasher, model.Password);

                    if (appUser is UnauthorisedUser || appUser is AnonymousUser)
                        return StatusCode(appUser.StatusCode, SetError("Failed to login"));
                }
                catch
                {
                    return BadRequest(SetError("Failed to login"));
                }

                var tokenData = tokenService().GenerateToken(null, appUser, model.RememberMe);

                var response = new
                {
                    token = tokenData.GetTokenString(),
                    expiration = tokenData.GetExpiry(),
                    expires_in = tokenData.GetExpiry()
                };

                return Ok(response);
            }
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}