using Microsoft.Extensions.Configuration;
using SpecialApp.Entity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface ITokenService
    {
        ITokenService GenerateToken(IConfigurationRoot config, SpecialAppUsers user, bool rememberMe=false);
        JwtSecurityToken GetToken();
        DateTime GetExpiry();
        string GetTokenString();
    }
}