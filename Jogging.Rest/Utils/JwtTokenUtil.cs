using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jogging.Api.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Jogging.Rest.Utils;

public static class JwtTokenUtil
{
    public static string Generate(JwtConfiguration configuration)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key));
        var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddDays(30),
            issuer: configuration.Issuer,
            audience: configuration.Audience,
            signingCredentials: signInCredentials
        );
        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(securityToken);
        
        return tokenString;
    }
}