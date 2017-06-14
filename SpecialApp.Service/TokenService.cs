using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class TokenService : ITokenService
    {
        private DateTime tokenExpiry { get; set; }
        private JwtSecurityToken token { get; set; }

        public ITokenService GenerateToken(IConfigurationRoot config, SpecialAppUsers user, bool rememberMe = false)
        {
            CreateToken(config, user, rememberMe);

            return this;
        }

        public DateTime GetExpiry()
        {
            return tokenExpiry;
        }

        public JwtSecurityToken GetToken()
        {
            return token;
        }

        public string GetTokenString()
        {
            return new JwtSecurityTokenHandler().WriteToken(GetToken());
        }

        private void CreateToken(IConfigurationRoot config, IAppUsers user, bool rememberMe = false)
        {
            var claims = new[]
            {
                //keep this sub at top this order is required. This sets the current user when getting instance of context
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AWESOMEKEYS!@#$%123456"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            this.tokenExpiry = SetExpiry(rememberMe);

            var token = new JwtSecurityToken(
                issuer: "https://specialapp.com",
                audience: "https://specialapp.com",
                claims: claims,
                expires: tokenExpiry,
                signingCredentials: creds
            );

            this.token = token;
        }

        private DateTime SetExpiry(bool rememberMe)
        {
#if DEBUG
            return DateTime.UtcNow.AddHours(5);
#else
            return rememberMe ? DateTime.UtcNow.AddDays(15) : DateTime.UtcNow.AddDays(1);
#endif
        }
    }
}
