using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpecialApp.API.Filters;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.Entity.Model.Account;
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

        public AuthController(Func<ICustomerService> customerServiceFunc, Func<IPasswordHasher<SpecialAppUsers>> hasher)
        {
            this.customerServiceFunc = customerServiceFunc;
            this.hasher = hasher;
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

                    if (appUser is UnauthorisedUser)
                        return StatusCode(401,  SetError("Failed to login"));

                    if(appUser is AnonymousUser)
                        return StatusCode(403, SetError("Failed to login"));
                }
                catch
                {
                    return BadRequest(SetError("Failed to login"));
                }

                JwtSecurityToken token = CreateToken(null, appUser, model.RememberMe);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    expires_in = SetExpiry(model.RememberMe)
                });
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

        private static JwtSecurityToken CreateToken(IConfigurationRoot config, IAppUsers user, bool rememberMe = false)
        {
            var claims = new[]
            {
                //keep this sub at top this order is required. This sets the current user when getting instance of context
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
            };

            //var userClaims = await userMgr.GetClaimsAsync(user);
            //if (userClaims.Count > 0)
            //    claims.Union(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AWESOMEKEYS!@#$%123456"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://specialapp.com",
                audience: "https://specialapp.com",
                claims: claims,
                expires: SetExpiry(rememberMe),
                signingCredentials: creds
            );
            return token;
        }

        private static DateTime SetExpiry(bool rememberMe)
        {
#if DEBUG
            return DateTime.UtcNow.AddHours(5);
#else
            return rememberMe ? DateTime.UtcNow.AddDays(15) : DateTime.UtcNow.AddDays(1);
#endif
        }
    }
}